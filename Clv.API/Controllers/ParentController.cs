using Clv.Models.ApiModelsDto.ParentsDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Services.Parent_Services;
using Clv.Services.Student_Service;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Clv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParentController : ControllerBase
    {
        private readonly IParentService _parentService;
        List<ParentDto> parentDtos;
        ParentDetailDto ParentDetailDto;
        ResponseDto responseDto;
        private List<StudentListDto> studentListDtos;
        private readonly IStudentService _studentService;
        public ParentController(IParentService parentService, IStudentService studentService)
        {
            _parentService = parentService;
            parentDtos = new List<ParentDto>();
            ParentDetailDto = new ParentDetailDto();
            responseDto = new ResponseDto();
            studentListDtos = new List<StudentListDto>();
            _studentService = studentService;
        }

        [HttpPost]
        [Route("AddStudent")]
        public IActionResult AddStudent(StudentRequestDto requestDto)
        {
            responseDto = _studentService.Add(requestDto);
            return Ok(responseDto);
        }

        [HttpGet]
        [Route("GetParentStudents/{ParentID}")]
        public IActionResult GetParentStudents(int ParentID)
        {
            if (ParentID <= 0)
            {
                return BadRequest("In valid request");
            }
            studentListDtos = _parentService.GetStudentList(ParentID);
            if (studentListDtos != null)
                return Ok(studentListDtos);
            else
                return NotFound();
        }



        [HttpGet]
        [Route("GetPendingPod/{ParentId}")]
        public IActionResult GetPendingPod(int ParentId)
        {

            var res = _parentService.GetParentPendingPods(ParentId);
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetPendingPodDetail/{{ParentPodID}}")]
        public IActionResult GetPendingPodDetail(int ParentPodID)
        {

            var res = _parentService.GetParentPendingPodDetail(ParentPodID);
            if (res != null)
                return Ok(res);
            else
                return NotFound();
        }


        [HttpGet]
        [Route("GetStudentDetail/{StudentID}")]
        public IActionResult GetStudentDetail(int StudentID)
        {
            if (StudentID <= 0)
            {
                return BadRequest("In valid request");
            }
            var studentDetail = _studentService.GetStudentDetail(StudentID);
            if (studentDetail != null)
                return Ok(studentDetail);
            else
                return NotFound();
        }


        [HttpGet]
        public IActionResult GetParentList()
        {
            parentDtos = _parentService.GetParentList();
            if (parentDtos.Count > 0)
                return Ok(parentDtos);
            else
                return NotFound(parentDtos);
        }

        [HttpGet]
        [Route("GetParentDetail/{UserID}")]
        public IActionResult GetParentDetail(int UserID)
        {
            if (UserID <= 0)
            {
                return BadRequest("User id is required");
            }
            ParentDetailDto = _parentService.GetParentDetail(UserID);
            if (ParentDetailDto != null)
                return Ok(ParentDetailDto);
            else
                return NotFound(ParentDetailDto);
        }


        [HttpPost]
        [Route("AssignPodToStudent")]
        public IActionResult AssignPodToStudent(PodStudentRquestDto obj)
        {
            responseDto = _parentService.AddStudentToPod(obj);
            return Ok(responseDto);
        }
    }
}
