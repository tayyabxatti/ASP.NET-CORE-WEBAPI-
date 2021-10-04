using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.SpecialNeedDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.SpecialNeed_Service
{
    public interface ISpecialNeedService
    {
        ResponseDto Add(SpecialNeedRequestDto obj);
        List<SpecialNeedListDto> GetSpecialNeedList();
    }
}
