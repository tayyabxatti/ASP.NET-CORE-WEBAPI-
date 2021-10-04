using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.GradeLevelDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.SpecialNeedDto;
using Clv.Models.Entities;
using Clv.Models.Entities.GradeLevelEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clv.Services.GradeLevel_Service
{
    public class GradeLevelService : IGradeLevelService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseDto responseDto;
        public GradeLevelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            responseDto = new ResponseDto();
        }
        public ResponseDto Add(GradeLevelRequestDto obj)
        {
            var gradeLevelRepo = _unitOfWork.GetRepository<GradeLevel>();
            try
            {
                GradeLevel gradeLevel = new GradeLevel()
                {
                    Name = obj.Name
                };
                gradeLevelRepo.Add(gradeLevel);
                _unitOfWork.Commit();
                return responseDto = new ResponseDto()
                {
                    Message = "Record hasbeen created successfully",
                    Success = true,
                };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<GradeLevelListDto> GetGradeLevelList()
        {
            try
            {
                var specialNeedRepo = _unitOfWork.GetRepository<GradeLevel>();
                return specialNeedRepo.GetAll().Select(r => new GradeLevelListDto()
                {
                    Name = r.Name,
                    GradeLevelID = r.GradeLevelID,

                }).ToList();
            }
            catch (Exception)
            {
                return new List<GradeLevelListDto>();
            }
        }
    }
}
