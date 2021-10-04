using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.ApiModelsDto.Subject;
using Clv.Models.Entities;
using Clv.Utilities.Hashing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clv.Services.Subject
{
    public class SubjectService : ISubjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        ResponseDto response;
        List<SubjectDto> subjectDtos;
        public SubjectService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            response = new ResponseDto();
        }
        public ResponseDto Create(SubjectRequestDto requesut)
        {
            var subjectRepo = _unitOfWork.GetRepository<Models.Entities.Subject>();
            try
            {
                Models.Entities.Subject subject = new Models.Entities.Subject()
                {
                    SubjectName = requesut.SubjectName,
                    CreatedDate = DateTime.Now,
                    CreatedBy = requesut.CreatedBy,
                    isActive = true,
                };
                subjectRepo.Add(subject);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has beeen created Successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ResponseDto Delete(int Id)
        {
            try
            {
                var subjectRepo = _unitOfWork.GetRepository<Models.Entities.Subject>();
                Models.Entities.Subject subject = subjectRepo.GetAll().Where(x => x.SubjectID == Id).FirstOrDefault();
                subject.isActive = false;
                subjectRepo.Update(subject);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has been deleted successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public SubjectDto Get(int Id)
        {
            SubjectDto subjectDtos = new SubjectDto();
            try
            {
                var subjectRepo = _unitOfWork.GetRepository<Models.Entities.Subject>();
                subjectDtos = subjectRepo.GetAll().Where(x => x.SubjectID == Id).Select(r => new SubjectDto()
                {
                    SubjectName = r.SubjectName,
                    CreatedDate = r.CreatedDate,
                    IsActive = true

                }).FirstOrDefault();

                return subjectDtos;
            }
            catch (Exception)
            {
                return new SubjectDto();
            }
        }

        public List<SubjectDto> GetSubjectList()
        {
            try
            {
                subjectDtos = new List<SubjectDto>();
                var subjectRepo = _unitOfWork.GetRepository<Models.Entities.Subject>();
                subjectDtos = subjectRepo.GetAll().Select(r => new SubjectDto()
                {
                    SubjectName = r.SubjectName,
                    CreatedDate = r.CreatedDate,
                    IsActive = true,

                }).ToList();

                return subjectDtos;
            }
            catch (Exception)
            {
                return new List<SubjectDto>();
            }
        }

        public ResponseDto Update(UpdateSubjectRequestDto requesut)
        {
            try
            {
                var subjectRepo = _unitOfWork.GetRepository<Models.Entities.Subject>();
                Models.Entities.Subject subject = subjectRepo.GetAll().Where(x => x.SubjectID == requesut.SubjectID).FirstOrDefault();
                subject.SubjectName = requesut.SubjectName;
                subjectRepo.Update(subject);
                _unitOfWork.Commit();
                return response = new ResponseDto()
                {
                    Success = true,
                    Message = "Record has been updated successfully"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<DropDownCommon> GetDropdown()
        {
            List<DropDownCommon> dropDowns = new List<DropDownCommon>();
            try
            {
                var repo = _unitOfWork.GetRepository<Models.Entities.Subject>();
                dropDowns = repo.GetAll().Select(r => new DropDownCommon()
                {
                    ID = r.SubjectID,
                    Name = r.SubjectName,
                }).ToList();
                return dropDowns;
            }
            catch (Exception)
            {
                return new List<DropDownCommon>();
            }
        }

    }
}
