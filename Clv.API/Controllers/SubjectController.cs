using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Models.ApiModelsDto.Subject;
using Clv.Services.Subject;
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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private ResponseDto response;
        List<SubjectDto> subjectDtos;
        SubjectDto subjectDto;
        public SubjectController(ISubjectService subjectService)
        {
            _subjectService = subjectService;
            subjectDtos = new List<SubjectDto>();
            subjectDto = new SubjectDto();
        }

        [HttpGet]
        public IActionResult DropDownSubject()
        {
            List<DropDownCommon> downCommons = new List<DropDownCommon>();
            downCommons = _subjectService.GetDropdown();
            if (downCommons.Count() > 0)
                return Ok(downCommons);
            return NotFound(downCommons);
        }

        [HttpGet]
        public IActionResult GetSubject()
        {
            subjectDtos = _subjectService.GetSubjectList();
            if (subjectDtos == null)
                return NotFound(subjectDtos);
            return Ok(subjectDtos);
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetSubjectByID(int Id)
        {
            if (Id == 0)
            {
                return BadRequest("In valid request");
            }
            subjectDto = _subjectService.Get(Id);
            if (subjectDto != null)
                return Ok(subjectDto);
            else
                return NotFound(new SubjectDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] SubjectRequestDto requestDto)
        {
             response = _subjectService.Create(requestDto);
                return Ok(response);
        }

    }
}
