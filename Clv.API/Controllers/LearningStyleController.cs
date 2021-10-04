using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Learning;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Services.LearningStyle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LearningStyleController : ControllerBase
    {
        private readonly ILearningService _learningService;
        private ResponseDto response;
        List<LearningStyleDto> learningDtos;
        LearningStyleDto learningDto;
        public LearningStyleController(ILearningService learningService)
        {
            _learningService = learningService;
            learningDtos = new List<LearningStyleDto>();
            learningDto = new LearningStyleDto();
        }

        [HttpGet]
        public IActionResult DropDownLearning()
        {
            List<DropDownCommon> downCommons = new List<DropDownCommon>();
            downCommons = _learningService.GetDropdown();
            if (downCommons.Count() > 0)
                return Ok(downCommons);
            return NotFound(downCommons);
        }

        [HttpGet]
        public IActionResult GetLearningStyle()
        {
            learningDtos = _learningService.GetSubjectList();
            if (learningDtos.Count() > 0)
                return Ok(learningDtos);
            return NotFound(learningDtos);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetLearningStyleByID(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("In valid request");
            }
            learningDto = _learningService.Get(Id);
            if (learningDto != null)
                return Ok(learningDto);
            else
                return NotFound(new LearningStyleDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] LearingStyleRequestDto requestDto)
        {
            response = _learningService.Create(requestDto);
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Update(UpdateLearningStyleRequestDto requestDto)
        {
            response = _learningService.Update(requestDto);
            return Ok(response);
        }
    }
}
