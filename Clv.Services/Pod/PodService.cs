using Clv.Core.Uow;
using Clv.Utilities.Hashing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using Clv.Models.Entities.PodNStudent;
using Clv.Models.ApiModelsDto.PodStudentDto;
using System.Linq;
using System.Data.SqlClient;
using System.Data;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.Entities.AssignmentEntity;
using Clv.Models.ApiModelsDto.ResponseDto;

namespace Clv.Services.Pod
{
    public class PodService : IPodService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;
        Response response;
        List<PodStudentsDto> podStudentsDto;
        List<AssignmentListDto> assignmentListDtos;
        public PodService(IUnitOfWork unitOfWork, IOptions<AppSettings> appSettings)
        {
            _unitOfWork = unitOfWork;
            _appSettings = appSettings.Value;
            podStudentsDto = new List<PodStudentsDto>();
            assignmentListDtos = new List<AssignmentListDto>();
        }

        public List<PodGetDto> GetPodList()
        {
            var result = _unitOfWork.SpRepository<PodGetDto>("sp_GetPodList");
            return result;
        }
        public List<PodStudentsDto> GetPodStudent(int PodId)
        {
            try
            {
                var p = new SqlParameter("@Pod_ID", SqlDbType.Int).Value = PodId;
                podStudentsDto = _unitOfWork.SpRepository<PodStudentsDto>("[dbo].[sp_GetPodStudentLst] {0}", p).ToList();
                return podStudentsDto;
            }
            catch (Exception ex)
            {
                return podStudentsDto = new List<PodStudentsDto>();
            }
        }

        public List<AssignmentListDto> GetPodAssignment(int Pod_ID)
        {
            try
            {
                var p = new SqlParameter("@Pod_ID", SqlDbType.Int).Value = (Convert.ToString(Pod_ID) ?? (object)DBNull.Value);
                assignmentListDtos = _unitOfWork.SpRepository<AssignmentListDto>("[dbo].[sp_GetPodAssignmentList] {0}", p).ToList();
                return assignmentListDtos;
            }
            catch (Exception)
            {
                return new List<AssignmentListDto>();
            }
        }

        public Response Create(PodRequestDto request)
        {
            try
            {
                var repo = _unitOfWork.GetRepository<POD>();
                POD POd = new POD()
                {
                    Title = request.Title,
                    Description = request.Description,
                    Tag = request.Tag,
                    LearningStyle_ID = request.LearningStyle_ID,
                    Subject_ID = request.Subject_ID,
                };
                repo.Add(POd);
                _unitOfWork.Commit();
                return response = new Response()
                {
                    StatusCode = "200",
                    Message = "Pod has been created successfylly"
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
        public Response AddAssignment(AssignmentDto assignmentDto)
        {
            try
            {
                var assignRepo = _unitOfWork.GetRepository<Models.Entities.AssignmentEntity.Assignment>();
                Models.Entities.AssignmentEntity.Assignment assignment = new Models.Entities.AssignmentEntity.Assignment();
                assignment.Title = assignmentDto.Title;
                assignment.Description = assignmentDto.Description;
                assignment.AssignedOn = assignmentDto.AssignedOn;
                assignment.LastDate = assignmentDto.LastDate;
                assignRepo.Save(assignment);
                _unitOfWork.Commit();
                var assignFileRepo = _unitOfWork.GetRepository<AssignmentFile>();
                List<AssignmentFile> assignmentFile = new List<AssignmentFile>();
                foreach (var item in assignmentDto.Files)
                {
                    assignmentFile.Add(new AssignmentFile()
                    { FileExt = item.Extension, Assignment_ID = assignment.AssignmentID, ContectType = item.ContentType, Data = item.File });
                }
                assignFileRepo.AddRanges(assignmentFile);
                _unitOfWork.Commit();
                return response = new Response()
                {
                    Success = true,
                    StatusCode = "Ok",
                    Message = "SUCESS"
                };

            }
            catch (Exception ex)
            {
                return response = new Response()
                {
                    Success = false,
                    StatusCode = "Error",
                    Message = ex.Message
                };
            }
        }

        public Response Update(PodEditDto request)
        {
            try
            {
                var podrepo = _unitOfWork.GetRepository<POD>();
                POD pOD = podrepo.GetAll().Where(c => c.PodID == request.PodID).SingleOrDefault();
                if (pOD == null)
                {
                    return response = new Response()
                    {
                        StatusCode = "404",
                        Message = "No record found"
                    };
                }
                pOD.Title = request.Title;
                pOD.Description = request.Description;
                pOD.Tag = request.Tag;
                pOD.LearningStyle_ID = request.LearningStyle_ID;
                pOD.Subject_ID = request.Subject_ID;
                pOD.Teacher_ID = request.Teacher_ID;
                pOD.isActive = true;
                podrepo.Update(pOD);
                _unitOfWork.Commit();
                return response = new Response()
                {
                    StatusCode = "200",
                    Message = "Pod has been updated successfully"
                };
            }
            catch (Exception)
            {
                return response = new Response()
                {
                    StatusCode = "Error",
                    Message = "Some thing went wrong plase try again later"
                };
            }
        }
    }
}
