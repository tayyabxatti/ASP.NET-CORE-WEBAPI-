using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.ApiModelsDto.ParentsDto;
using Clv.Models.ApiModelsDto.POD;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Models.ApiModelsDto.TeacherDtos;
using Clv.Models.Entities.PodNStudent;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Clv.Services.Parent_Services
{
    public class ParentService : IParentService
    {
        private readonly IUnitOfWork _unitOfWork;
        List<ParentDto> parentDtos;
        ParentDetailDto ParentDetalDto;
        List<CovidAnswereDetailDto> covidAnswereDetailDtos;
        List<StudentListDto> studentListDtos;
        TeacherDetailDto teacher;
        ResponseDto responseDto;
        public ParentService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            covidAnswereDetailDtos = new List<CovidAnswereDetailDto>();
            studentListDtos = new List<StudentListDto>();
            teacher = new TeacherDetailDto();
        }

        public List<CovidAnswereDetailDto> GetParentAnswereDetail(int UserID)
        {
            try
            {
                var p = new SqlParameter("@UserID", SqlDbType.Int).Value = UserID;
                covidAnswereDetailDtos = _unitOfWork.SpRepository<CovidAnswereDetailDto>("[dbo].[Sp_GetCovidParentAnswere] {0}", p).ToList();
                return covidAnswereDetailDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ParentDetailDto GetParentDetail(int UserID)
        {
            try
            {
                ParentDetalDto = new ParentDetailDto();
                var p = new SqlParameter("@userid", SqlDbType.Int).Value = UserID;
                ParentDetalDto = _unitOfWork.SpRepository<ParentDetailDto>("[dbo].[sp_GetParentDetail] {0}", p).FirstOrDefault();
                return ParentDetalDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<ParentDto> GetParentList()
        {
            try
            {
                parentDtos = new List<ParentDto>();
                parentDtos = _unitOfWork.SpRepository<ParentDto>("[dbo].[Sp_GetParentList]").ToList();
                return parentDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<StudentListDto> GetStudentList(int ParentID)
        {

            try
            {
                var ID = new SqlParameter("@ParentID", SqlDbType.Int).Value = (Convert.ToString(ParentID) ?? (object)DBNull.Value);
                studentListDtos = _unitOfWork.SpRepository<StudentListDto>("[dbo].[Sp_GetParentChildList] {0}", ID).ToList();
                return studentListDtos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PendingPodDto> GetParentPendingPods(int ParentID)
        {

            try
            {
                var ID = new SqlParameter("@ParentID", SqlDbType.Int).Value = (Convert.ToString(ParentID) ?? (object)DBNull.Value);
                var res = _unitOfWork.SpRepository<PendingPodDto>("[dbo].[sp_GetPendinPodList] {0}", ID).ToList();
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public TeacherDetailDto GetTeacherDetail(int UserID)
        {
            try
            {
                var p = new SqlParameter("@userid", SqlDbType.Int).Value = UserID;
                teacher = _unitOfWork.SpRepository<TeacherDetailDto>("[dbo].[sp_GetTeacherDetail] {0}", p).FirstOrDefault();
                return teacher;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public PendingPodDetailDto GetParentPendingPodDetail(int ParentPodID)
        {
            PendingPodDetailDto pendingPodDetailDto = new PendingPodDetailDto();

            try
            {
                var ID = new SqlParameter("@ParentPodID", SqlDbType.Int).Value = (Convert.ToString(ParentPodID) ?? (object)DBNull.Value);
                pendingPodDetailDto = _unitOfWork.SpRepository<PendingPodDetailDto>("[dbo].[Sp_GetPendingPodDetail] {0}", ID).FirstOrDefault();
                return pendingPodDetailDto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseDto AddStudentToPod(PodStudentRquestDto obj)
        {
            try
            {

                var repo = _unitOfWork.GetRepository<PodStudent>();
                PodStudent podStudentsearh = repo.GetAll().Where(r => r.Pod_ID == obj.PodID && r.Student_ID == obj.StudentID).FirstOrDefault();
                
                if (podStudentsearh != null)
                {
                    return responseDto = new ResponseDto()
                    {
                        Success = false,
                        Message = "Student already added in the same pod"
                    };
                }

                PodStudent podStudent = new PodStudent()
                {
                    Student_ID = obj.StudentID,
                    Pod_ID = obj.PodID
                };
                repo.Add(podStudent);
                _unitOfWork.Commit();
                return responseDto = new ResponseDto()
                {
                    Success = true,
                    Message = "Pod has been created successfylly"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
