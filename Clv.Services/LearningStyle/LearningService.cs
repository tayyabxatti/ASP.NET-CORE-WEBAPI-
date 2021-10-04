using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Learning;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.Entities;

namespace Clv.Services.LearningStyle
{
    public class LearningService : ILearningService
    {
        private readonly IUnitOfWork _unitOfWork;
        ResponseDto response;
        List<LearningStyleDto> learningDtos;


        public LearningService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseDto();
        }

        public ResponseDto Create(LearingStyleRequestDto requesut)
        {
            var learingRepo = _unitOfWork.GetRepository<LearingStyle>();
            try
            {
                LearingStyle learingStyle = new LearingStyle()
                {
                    Title = requesut.Title,
                    CreatedDate = DateTime.Now,
                    CreatedBy = requesut.CreatedBy,
                    isActive = true,
                };
                learingRepo.Add(learingStyle);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has beeen created Successfully"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public ResponseDto Delete(int Id)
        {
            try
            {
                var lreaningRepo = _unitOfWork.GetRepository<LearingStyle>();
                LearingStyle learing = lreaningRepo.GetAll().Where(x => x.LearningStyleID == Id).FirstOrDefault();
                learing.isActive = false;
                lreaningRepo.Update(learing);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has been deleted successfully"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public LearningStyleDto Get(int Id)
        {
            LearningStyleDto styleRequestDto = new LearningStyleDto();
            try
            {
                var repoLearing = _unitOfWork.GetRepository<LearingStyle>();
                styleRequestDto = repoLearing.GetAll().Where(x => x.LearningStyleID == Id).Select(r => new LearningStyleDto()
                {
                    Title = r.Title,
                    CreatedDate = r.CreatedDate,
                    IsActive = r.isActive
                }).FirstOrDefault();

                return styleRequestDto;
            }
            catch (Exception)
            {
                return new LearningStyleDto();
            }
        }
        public List<LearningStyleDto> GetSubjectList()
        {
            try
            {
                learningDtos = new List<LearningStyleDto>();
                var subjectRepo = _unitOfWork.GetRepository<LearingStyle>();
                learningDtos = subjectRepo.GetAll().Select(r => new LearningStyleDto()
                {
                    Title = r.Title,
                    CreatedDate = r.CreatedDate,
                    IsActive = true,
                }).ToList();
                return learningDtos;
            }
            catch (Exception)
            {
                return new List<LearningStyleDto>();
            }
        }
        public ResponseDto Update(UpdateLearningStyleRequestDto request)
        {
            try
            {
                var subjectRepo = _unitOfWork.GetRepository<Models.Entities.LearingStyle>();
                Models.Entities.LearingStyle learingStyle = subjectRepo.GetAll().Where(x => x.LearningStyleID == request.LearningStyleID).FirstOrDefault();
                learingStyle.Title = request.Title;
                subjectRepo.Update(learingStyle);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has been updated successfully"
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<DropDownCommon> GetDropdown()
        {
            List<DropDownCommon> dropDowns = new List<DropDownCommon>();
            try
            {
                var repo = _unitOfWork.GetRepository<LearingStyle>();
                dropDowns = repo.GetAll().Select(r => new DropDownCommon()
                {
                    ID = r.LearningStyleID,
                    Name = r.Title,
                }).ToList();
                return dropDowns;
            }
            catch (Exception ex)
            {
                return new List<DropDownCommon>();
            }
        }
    }
}
