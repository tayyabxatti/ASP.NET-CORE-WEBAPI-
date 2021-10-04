using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using Clv.Models.ApiModelsDto.DropDown;
using Clv.Models.ApiModelsDto.GradeLevelDto;
using Clv.Models.ApiModelsDto.Learning;
using Clv.Models.ApiModelsDto.ParentsDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.SpecialNeedDto;
using Clv.Models.ApiModelsDto.StudentDto;
using Clv.Models.ApiModelsDto.Subject;
using Clv.Models.ApiModelsDto.TeacherDtos;
using Clv.Services.Authenticate;
using Clv.Services.GradeLevel_Service;
using Clv.Services.LearningStyle;
using Clv.Services.Parent_Services;
using Clv.Services.SpecialNeed_Service;
using Clv.Services.Student_Service;
using Clv.Services.Subject;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clv.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IParentService _parentService;
        ResponseDto responseDto;
        List<ParentDto> parentDtos;
        ParentDetailDto ParentDetailDto;
        TeacherDetailDto TeacherDetailDto;
        IAuthenticateService _authenticateService;
        List<TeacherListDto> teacherListDtos = new List<TeacherListDto>();
        List<CovidAnswereDetailDto> covidAnswereDetailDtos;
        private readonly ISpecialNeedService _specialneedService;
        private readonly IGradeLevelService _gradeLevelService;
        private readonly ISubjectService _subjectService;
        private readonly IStudentService _studentService;
        private List<SubjectDto> subjectDtos;
        private SubjectDto subjectDto;
        private readonly ILearningService _learningService;

        private ResponseDto response;
        List<LearningStyleDto> learningDtos;
        LearningStyleDto learningDto;
        public AdminController(IParentService parentService, IAuthenticateService authenticateService
            , ISpecialNeedService needService, IGradeLevelService gradeLevel, IStudentService studentService
            , ISubjectService subjectService, ILearningService learningService)
        {
            _parentService = parentService;
            parentDtos = new List<ParentDto>();
            ParentDetailDto = new ParentDetailDto();
            _authenticateService = authenticateService;
            covidAnswereDetailDtos = new List<CovidAnswereDetailDto>();
            TeacherDetailDto = new TeacherDetailDto();
            responseDto = new ResponseDto();
            _specialneedService = needService;
            _gradeLevelService = gradeLevel;
            _studentService = studentService;
            _subjectService = subjectService;
            _learningService = learningService;
            subjectDtos = new List<SubjectDto>();
            subjectDto = new SubjectDto();

        }

        [HttpGet]
        [Route("GetParentList")]
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


        [HttpGet]
        [Route("GetTecherDetail/{UserID}")]
        public IActionResult GetTecherDetail(int UserID)
        {
            if (UserID <= 0)
            {
                return BadRequest("User id is required");
            }
            TeacherDetailDto = _parentService.GetTeacherDetail(UserID);
            if (TeacherDetailDto != null)
                return Ok(TeacherDetailDto);
            else
                return NotFound(ParentDetailDto);
        }

        [HttpGet]
        [Route("GetParentAnswereDetail/{UserID}")]
        public IActionResult GetParentAnswereDetail(int UserID)
        {
            if (UserID <= 0)
            {
                return BadRequest("User id is required");
            }
            covidAnswereDetailDtos = _parentService.GetParentAnswereDetail(UserID);
            if (covidAnswereDetailDtos != null)
                return Ok(covidAnswereDetailDtos);
            else
                return NotFound(covidAnswereDetailDtos);
        }


        

        [HttpGet]
        [Route("GetTeacherList")]
        public IActionResult GetTeacherList()
        {
            teacherListDtos = _authenticateService.GetTeacherList();
            if (teacherListDtos != null)
                return Ok(teacherListDtos);
            else
                return NotFound(teacherListDtos);
        }

        [HttpPost]
        [Route("AddGradeLevel")]
        public IActionResult AddGradeLevel(GradeLevelRequestDto gradeLevel)
        {
            responseDto = _gradeLevelService.Add(gradeLevel);
            return Ok(responseDto);
        }

        [HttpPost]
        [Route("AddSepcialNeed")]
        public IActionResult AddSepcialNeed(SpecialNeedRequestDto requestDto)
        {
            responseDto = _specialneedService.Add(requestDto);
            return Ok(responseDto);
        }

        [HttpGet]
        [Route("GetGradeLevel")]
        public IActionResult GetGradeLevel()
        {
            return Ok(_gradeLevelService.GetGradeLevelList());
        }

        [HttpGet]
        [Route("GetSpecialNeedService")]
        public IActionResult GetSpecialNeedService()
        {
            return Ok(_specialneedService.GetSpecialNeedList());
        }

        [HttpGet]
        [Route("DropDownSubject")]

        public IActionResult DropDownSubject()
        {
            List<DropDownCommon> downCommons = new List<DropDownCommon>();
            downCommons = _subjectService.GetDropdown();
            if (downCommons.Count() > 0)
                return Ok(downCommons);
            return NotFound(downCommons);
        }

        [HttpGet]
        [Route("GetSubjectList")]
        public IActionResult GetSubjectList()
        {
            subjectDtos = _subjectService.GetSubjectList();
            if (subjectDtos == null)
                return NotFound(subjectDtos);
            return Ok(subjectDtos);
        }

        [HttpGet]
        [Route("GetSubjectByID/{Id}")]
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
        [Route("AddSubject")]
        public IActionResult AddSubject(SubjectRequestDto requestDto)
        {
            responseDto = _subjectService.Create(requestDto);
            return Ok(responseDto);
        }

        [HttpPut]
        [Route("UpdateSubject")]
        public IActionResult UpdateSubject(UpdateSubjectRequestDto requestDto)
        {
            responseDto = _subjectService.Update(requestDto);
            return Ok(responseDto);
        }

        [HttpGet]
        [Route("DropDownLearning")]
        public IActionResult DropDownLearning()
        {
            List<DropDownCommon> downCommons = new List<DropDownCommon>();
            downCommons = _learningService.GetDropdown();
            if (downCommons.Count() > 0)
                return Ok(downCommons);
            return NotFound(downCommons);
        }

        [HttpGet]
        [Route("GetLearningStyleList")]
        public IActionResult GetLearningStyleList()
        {
            learningDtos = _learningService.GetSubjectList();
            if (learningDtos.Count() > 0)
                return Ok(learningDtos);
            return NotFound(learningDtos);
        }

        [HttpGet]
        [Route("GetLearningStyleByID/{Id}")]
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
        [Route("AddLearningStyle/{Id}")]
        public IActionResult AddLearningStyle(LearingStyleRequestDto requestDto)
        {
            response = _learningService.Create(requestDto);
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateLearningStyle")]
        public IActionResult UpdateLearningStyle(UpdateLearningStyleRequestDto requestDto)
        {
            response = _learningService.Update(requestDto);
            return Ok(response);
        }

        [HttpPost]
        [Route("ChangeTeacherStatus")]
        public IActionResult ChangeTeacherStatus(TeacherStatusDto teacherStatusDto)
        {
            response = _authenticateService.ChangeTeacherStatus(teacherStatusDto);
            return Ok(response);
        }

    }
}
