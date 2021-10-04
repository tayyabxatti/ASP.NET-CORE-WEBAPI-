using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.SpecialNeedDto;
using Clv.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clv.Services.SpecialNeed_Service
{
    public class SpecialNeedService : ISpecialNeedService
    {
        private readonly IUnitOfWork _unitOfWork;
        private ResponseDto responseDto;
        public SpecialNeedService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            responseDto = new ResponseDto();
        }
        public ResponseDto Add(SpecialNeedRequestDto obj)
        {
            var specialNeedRepo = _unitOfWork.GetRepository<SpecialNeed>();
            try
            {
                SpecialNeed specialNeed = new SpecialNeed()
                {
                    Name = obj.Name
                };
                specialNeedRepo.Add(specialNeed);
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

        public List<SpecialNeedListDto> GetSpecialNeedList()
        {
            try
            {
                var specialNeedRepo = _unitOfWork.GetRepository<SpecialNeed>();
                return specialNeedRepo.GetAll().Select(r => new SpecialNeedListDto()
                {
                    Name = r.Name,
                    SpecialNeedID = r.SpecialNeedID,

                }).ToList();
            }
            catch (Exception)
            {
                return new List<SpecialNeedListDto>();
            }
        }
    }
}
