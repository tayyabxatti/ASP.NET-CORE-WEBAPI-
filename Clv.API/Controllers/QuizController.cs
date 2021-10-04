using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clv.Models.ApiModelsDto.QuizDto;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Services.Quiz;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clv.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QuizController : ControllerBase
    {
        private readonly IQuizService _quizService;
        private QuizDto quizDto;
        private Response response;
        List<QuizList> quizList;
        List<QuizResultDto> quizResults;
        public QuizController(IQuizService iquizService)
        {
            _quizService = iquizService;
            quizDto = new QuizDto();
            quizList = new List<QuizList>();
            quizResults = new List<QuizResultDto>();
        }

        [HttpGet]
        [Route("{PodID}")]
        public IActionResult QuizListByID(int PodID)
        {
            if (PodID <= 0)
            {
                return BadRequest("In valid request");
            }
            quizList = _quizService.GetQuizList(PodID);
            if (quizList != null)
                return Ok(quizList);
            else
                return NotFound(quizList);
        }

        [HttpGet]
        [Route("{QuizID}")]
        public IActionResult QuizResultByID(int QuizID)
        {
            if (QuizID <= 0)
            {
                return BadRequest("In valid request");
            }
            quizResults = _quizService.GetQuizResult(QuizID);
            if (quizResults != null)
                return Ok(quizResults);
            else
                return NotFound();
        }

        [HttpGet]
        [Route("{QuizID}")]
        public IActionResult QuizDetailListByID(int QuizID)
        {
            if (QuizID <= 0)
            {
                return BadRequest("In valid request");
            }
            quizDto = _quizService.Get(QuizID);
            if (quizDto != null)
                return Ok(quizDto);
            else
                return NotFound(quizDto);
        }

        [HttpPost]
        public IActionResult Create([FromBody] QuizRequestDto quizRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            response = _quizService.Create(quizRequestDto);
            if (response.StatusCode == "200")
                return Ok(response);
            else
                return BadRequest(response);
        }

        [HttpPost]
        public IActionResult SubmitQuiz([FromBody] QuizRequestSubmitDto submitDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            response = _quizService.SubmitQuiz(submitDto);
            if (response.StatusCode == "200")
                return Ok(response);
            else
                return BadRequest(response);
        }
    }
}
