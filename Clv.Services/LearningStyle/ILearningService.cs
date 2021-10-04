using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Learning;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.LearningStyle
{
    public interface ILearningService
    {
        public List<DropDownCommon> GetDropdown();
        ResponseDto Create(LearingStyleRequestDto requesut);
        LearningStyleDto Get(int Id);
        List<LearningStyleDto> GetSubjectList();
        ResponseDto Update(UpdateLearningStyleRequestDto request);
        ResponseDto Delete(int Id);
    }
}
