using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Services.Assignment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;
        private ResponseDto response;
        List<AssignmentListDto> assignmentListDtos;
        AssignmentDetailDto assignmentDetailDto;
        List<AssignmentSubmitedDto> assignmentSubmitedDtos;
        public AssignmentController(IAssignmentService iassignmentService)
        {
            _assignmentService = iassignmentService;
            assignmentListDtos = new List<AssignmentListDto>();
            assignmentDetailDto = new AssignmentDetailDto();
            assignmentSubmitedDtos = new List<AssignmentSubmitedDto>();
        }

        [HttpPost]
        public IActionResult SubmitAssignment([FromBody] AssignmentSubmitDto assignmentSubmitDto)
        {
            response = _assignmentService.SubmitAssignment(assignmentSubmitDto);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create([FromBody] AssignmentDto assignmentDto)
        {
            response = _assignmentService.Create(assignmentDto);
            return Ok(response);

        }

        [HttpGet]
        [Route("{AssignmentID}")]
        public IActionResult StudentAssignmentDetail(int AssignmentID)
        {
            if (AssignmentID <= 0)
            {
                return BadRequest("In valid request");
            }
            assignmentSubmitedDtos = _assignmentService.GetStudentAssignmentDetail(AssignmentID);
            if (assignmentSubmitedDtos != null)
                return Ok(assignmentSubmitedDtos);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("{PodID}")]
        public IActionResult GetAssignmentList(int PodID)
        {
            if (PodID <= 0)
            {
                return BadRequest("In valid request");
            }
            assignmentListDtos = _assignmentService.GetList(PodID);
            if (assignmentListDtos.Count > 0)
                return Ok(assignmentListDtos);
            else
                return NotFound(assignmentListDtos);
        }

        [HttpGet]
        [Route("{AssignmentID}")]
        public IActionResult GetDetails(int AssignmentID)
        {

            if (AssignmentID <= 0)
            {
                return BadRequest("In valid request");
            }
            assignmentDetailDto = _assignmentService.GetDetailByID(AssignmentID);
            if (assignmentDetailDto != null)
                return Ok(assignmentDetailDto);
            else
                return NotFound(assignmentDetailDto);
        }
    }
}