using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.ApiModelsDto.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Subject
{
    public interface ISubjectService
    {
        public List<DropDownCommon> GetDropdown();
        ResponseDto Create(SubjectRequestDto requesut);
        SubjectDto Get(int Id);
        List<SubjectDto> GetSubjectList();
        ResponseDto Update(UpdateSubjectRequestDto request);
        ResponseDto Delete(int Id);
    }
}
