using Clv.Core.Uow;
using Clv.Utilities.Hashing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Clv.Models.Entities.PodNStudent;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.Entities.AssignmentEntity;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.ApiModelsDto.QuizDto;
using Clv.Models.Entities.QuizEntity;

namespace Clv.Services.Quiz
{
    public class QuizService : IQuizService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        Response response;
        QuizDto quizDto;
        List<QuizList> quizLists;
        List<QuizResultDto> quizResults;
        public QuizService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            quizLists = new List<QuizList>();
            quizResults = new List<QuizResultDto>();
        }

        public List<QuizResultDto> GetQuizResult(int QuizID)
        {
            try
            {
                var pQID = new SqlParameter("@QuizID", SqlDbType.Int).Value = (Convert.ToString(QuizID) ?? (object)DBNull.Value);
                quizResults = _unitOfWork.SpRepository<QuizResultDto>("[dbo].[sp_GetQuizSubmitedStudent] {0}", pQID).ToList();
                return quizResults;
            }
            catch (Exception ex)
            {
                return new List<QuizResultDto>();
            }
        }

        public List<QuizList> GetQuizList(int ID)
        {
            try
            {
                var p = new SqlParameter("@Pod_ID", SqlDbType.Int).Value = (Convert.ToString(ID) ?? (object)DBNull.Value);
                quizLists = _unitOfWork.SpRepository<QuizList>("[dbo].[sp_GetPodQuizList] {0}", p).ToList();
                return quizLists;
            }
            catch (Exception)
            {
                return new List<QuizList>();
            }
        }

        public QuizDto Get(int QuizID)
        {
            List<QuizListDto> quizDetailDtos = new List<QuizListDto>();
            try
            {
                var pQID = new SqlParameter("@QuizID", SqlDbType.Int).Value = (Convert.ToString(QuizID) ?? (object)DBNull.Value);
                quizDetailDtos = _unitOfWork.SpRepository<QuizListDto>("[dbo].[sp_GetQuizDetailByID] {0}", pQID).ToList();

                if (quizDetailDtos.Count > 0)
                {
                    quizDto = new QuizDto()
                    {
                        QuizID = quizDetailDtos.FirstOrDefault().QuizID,
                        Title = quizDetailDtos.FirstOrDefault().Title,
                        TotalMarks = quizDetailDtos.FirstOrDefault().TotalMarks,
                        StartDate = quizDetailDtos.FirstOrDefault().StartDate,
                        EndDate = quizDetailDtos.FirstOrDefault().EndDate,
                        Pod_ID = quizDetailDtos.FirstOrDefault().Pod_ID,
                    };
                    quizDto.questionDtos = (List<QuestionDto>)quizDetailDtos.GroupBy(x => new
                    {
                        x.QuizQuestionsID,
                        x.Quiz_ID,
                        x.QuestionType,
                        x.Question,
                    }).Select(gcs => new QuestionDto()
                    {
                        QuizQuestionsID = gcs.Key.QuizQuestionsID,
                        Quiz_ID = gcs.Key.Quiz_ID,
                        QuestionType = gcs.Key.QuestionType,
                        Question = gcs.Key.Question,
                        OptionDtos = quizDetailDtos.Where(o => o.QuizQuestionsID == gcs.Key.QuizQuestionsID).Select(r => new OptionDto()
                        {
                            QuizQuestionOptionID = r.QuizQuestionOptionID,
                            QuizQuestions_ID = r.QuizQuestions_ID,
                            IsCorrectOption = r.IsCorrectOption,
                            Option = r.Option
                        }).ToList()
                    }).ToList();
                }
                return quizDto;
            }
            catch (Exception ex)
            {
                quizDto = new QuizDto();
            }
            return quizDto;
        }



        public Response Create(QuizRequestDto ParamQuizRequestDto)
        {
            try
            {
                var repoQuiz = _unitOfWork.GetRepository<Models.Entities.QuizEntity.Quiz>();
                Models.Entities.QuizEntity.Quiz quiz = new Models.Entities.QuizEntity.Quiz();
                quiz.Title = ParamQuizRequestDto.Title;
                quiz.Decription = ParamQuizRequestDto.Decription;
                quiz.StartDate = ParamQuizRequestDto.StartDate;
                quiz.EndDate = ParamQuizRequestDto.EndDate;
                quiz.StartTime = ParamQuizRequestDto.StartTime;
                quiz.EndTime = ParamQuizRequestDto.EndTime;
                quiz.IsActive = true;
                repoQuiz.Save(quiz);
                _unitOfWork.Commit();

                var repoQuizQuestion = _unitOfWork.GetRepository<Models.Entities.QuizEntity.QuizQuestions>();
                var repoQuizQuestionOption = _unitOfWork.GetRepository<Models.Entities.QuizEntity.QuizQuestionOption>();

                foreach (var itemQestion in ParamQuizRequestDto.quizQuestionDtosList)
                {
                    Models.Entities.QuizEntity.QuizQuestions questions = new Models.Entities.QuizEntity.QuizQuestions();
                    questions.Question = itemQestion.Question;
                    questions.QuestionType = itemQestion.QuestionType;
                    questions.Quiz_ID = itemQestion.Quiz_ID;
                    itemQestion.Quiz_ID = quiz.QuizID;

                    repoQuizQuestion.Add(questions);
                    _unitOfWork.Commit();

                    foreach (var Option in itemQestion.OptionDto)
                    {
                        Models.Entities.QuizEntity.QuizQuestionOption mdlOption = new Models.Entities.QuizEntity.QuizQuestionOption();

                        mdlOption.Option = Option.Option;
                        mdlOption.IsCorrectOption = Option.IsCorrectOption;
                        Option.QuizQuestions_ID = questions.QuizQuestionsID;
                        mdlOption.QuizQuestions_ID = Option.QuizQuestions_ID;
                        repoQuizQuestionOption.Add(mdlOption);
                        _unitOfWork.Commit();
                    }
                }
                return response = new Response()
                {
                    StatusCode = "200",
                    Message = "Quiz has been created successfylly"
                };
            }
            catch (Exception)
            {
                return response = new Response()
                {
                    StatusCode = "Error",
                    Message = "Some thing went wrong please try again later"
                };
            }
        }

        public Response SubmitQuiz(QuizRequestSubmitDto submitDto)
        {
            try
            {
                var repoSumit = _unitOfWork.GetRepository<Models.Entities.QuizEntity.QuizSubmited>();
                Models.Entities.QuizEntity.QuizSubmited submit = new Models.Entities.QuizEntity.QuizSubmited()
                {
                    SubmitedDate = DateTime.Now,
                    IsActive = true,
                    Student_ID = submitDto.Student_ID,
                    Quiz_ID = submitDto.Quiz_ID,
                    Status = "Pending"
                };
                repoSumit.Save(submit);
                _unitOfWork.Commit();

                var repoSumitDetail = _unitOfWork.GetRepository<QuizSubmitedDetail>();
                List<QuizSubmitedDetail> details = new List<QuizSubmitedDetail>();
                foreach (var itemDetail in submitDto.quizSubmitedDetails)
                {
                    details.Add(new QuizSubmitedDetail()
                    {
                        CreatedDate = DateTime.Now,
                        Question_ID = itemDetail.Question_ID,
                        QuesionOption_ID = itemDetail.QuesionOption_ID,
                        QuizSubmited_ID = submit.QuizSubmitedID,
                    });
                }
                repoSumitDetail.AddRanges(details);
                _unitOfWork.Commit();

                return response = new Response()
                {
                    StatusCode = "200",
                    Message = "Quiz has been submitted successfully"
                };
            }
            catch (Exception)
            {
                return response = new Response()
                {
                    StatusCode = "Error",
                    Message = "Some thing wrong please try again later"
                };
            }
        }
    }
}
