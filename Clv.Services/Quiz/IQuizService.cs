using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.QuizDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Quiz
{
    public interface IQuizService
    {
        public List<QuizResultDto> GetQuizResult(int QuizID);
        public List<QuizList> GetQuizList(int Pod_ID);
        public Response Create(QuizRequestDto ParamQuizRequestDto);
        public QuizDto Get(int QuizID);
        public Response SubmitQuiz(QuizRequestSubmitDto ParamQuizRequestDto);
    }
}
