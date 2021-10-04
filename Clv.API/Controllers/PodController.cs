using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.AssignmentDto;
using Clv.Models.ApiModelsDto.PodStudentDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Services.Pod;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PodController : ControllerBase
    {
        private readonly IPodService _podService;
        private Response response;
        List<PodGetDto> podGetDtos;
        List<PodStudentsDto> podStudentsDtos;
        List<AssignmentListDto> assignmentListDtos;
        public PodController(IPodService iPodService)
        {
            _podService = iPodService;
            podGetDtos = new List<PodGetDto>();
            assignmentListDtos = new List<AssignmentListDto>();
            podStudentsDtos = new List<PodStudentsDto>();
        }

        [HttpGet]
        public IActionResult GetPod()
        {
            podGetDtos = _podService.GetPodList();
            if (podGetDtos == null)
                return NotFound(podGetDtos);
            return Ok(podGetDtos);
        }

        [HttpGet]
        [Route("{PId}")]
        public IActionResult GetPodStudent(int PId)
        {
            if (PId == 0)
            {
                return BadRequest("In valid request");
            }
            podStudentsDtos = _podService.GetPodStudent(PId);
            if (podStudentsDtos.Count() > 0)
                return Ok(podStudentsDtos);
            else
                return NotFound(podStudentsDtos);
        }

        [HttpGet]
        [Route("{PodId}")]
        public IActionResult GetPodAssignment(int PodId)
        {
            if (PodId <= 0)
            {
                return BadRequest("Pod id is required");
            }
            assignmentListDtos = _podService.GetPodAssignment(PodId);
            if (assignmentListDtos.Count() > 0)
                return Ok(assignmentListDtos);
            else
                return NotFound(assignmentListDtos);
        }


        [HttpPost]
        public IActionResult Create([FromBody] PodRequestDto podInsert)
        {
            response = _podService.Create(podInsert);
            if (response.StatusCode == "200")
                return Ok(response);
            else
                return Unauthorized(response);
        }


        [HttpPut]
        public IActionResult UpdatePod([FromBody] PodEditDto request)
        {
            response = _podService.Update(request);
            if (response.StatusCode == "200")
            {
                return Ok(response);
            }
            if (response.StatusCode == "404")
                return NotFound(response);
            else
                return StatusCode((int)System.Net.HttpStatusCode.InsufficientStorage, response);
        }
    }
}
