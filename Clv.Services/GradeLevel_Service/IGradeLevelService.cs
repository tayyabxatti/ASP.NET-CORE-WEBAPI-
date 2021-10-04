using Clv.Models.ApiModelsDto.GradeLevelDto;
using Clv.Models.ApiModelsDto.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.GradeLevel_Service
{
    public interface IGradeLevelService
    {
        ResponseDto Add(GradeLevelRequestDto obj);
        List<GradeLevelListDto> GetGradeLevelList();
    }
}
