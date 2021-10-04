using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Clv.Models.ApiModels.AuthenticateDto;
using Clv.Models.ApiModelsDto.AuthDto;
using Clv.Services.Authenticate;
using System.Linq;
using Clv.Models.Response;
using Microsoft.AspNetCore.Http;
using Clv.Models.ApiModelsDto.ParentDto;
using Clv.Models.ApiModelsDto.Response;
using Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto;
using System.Collections.Generic;
using Clv.Models.ApiModelsDto.TeacherDtos;

namespace Clv.API.Controllers
{

    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        ResponseDto responseDto; 
        public ResponseMessage responseMessage;
        private readonly IAuthenticateService _authenticateService;
        public AuthenticateController(IAuthenticateService authenticateService)
        {
            _authenticateService = authenticateService;
            responseDto = new ResponseDto();
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(LoginDto _credentials)
        {
            var user = _authenticateService.Authenticate(_credentials);
            if (user.ErrorMessage != null)
                return Unauthorized(user.ErrorMessage);
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetRoles()
        {
            var user = _authenticateService.GetRole();
            if (user == null)
                return Unauthorized("No Roles in the system");
            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Register(RegisterDto registerDto)
        {
            try
            {
                var registerUser = _authenticateService.Register(registerDto);
                if (registerUser.Status == "BAD")
                    return Ok(registerUser);
                else
                    return Ok(registerUser);
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }


        [AllowAnonymous]
        [HttpGet]
        [Route("{key}")]
        public IActionResult VerifyEmail(string key)
        {
            try
            {
                if (string.IsNullOrEmpty(key))
                {
                    return BadRequest("In valid request");
                }
                if (_authenticateService.VerifyEmail(key))
                    return Ok(true);
                else
                    return Unauthorized();
            }
            catch (System.Exception)
            {
                throw;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{UserID}")]
        public IActionResult UserDetailByID(string UserID)
        {
            try
            {
                if (string.IsNullOrEmpty(UserID))
                {
                    return BadRequest("In valid request");
                }
                var UserDetail = _authenticateService.GetUserByID(int.Parse(UserID));
                if (UserDetail != null)
                    return Ok(UserDetail);
                else
                    return NotFound();
            }
            catch (System.Exception)
            {
                throw;
            }
        }


        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult UpdateUserProfile([FromBody] UpdateUserRequestDto updateRqeuestDto)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            responseMessage = new ResponseMessage()
        //            {
        //                HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
        //                Message = "One or more validation error occur",
        //            };
        //            return BadRequest(responseMessage);
        //        }
        //        _authenticateService.UpdateUserProfile(updateRqeuestDto);
        //        responseMessage = new ResponseMessage()
        //        {
        //            HttpStatusCode = System.Net.HttpStatusCode.OK,
        //            Message = "Profile has been updated successfully"
        //        };
        //        return Ok(responseMessage);
        //    }
        //    catch (System.Exception ex)
        //    {
        //        responseMessage = new ResponseMessage()
        //        {
        //            HttpStatusCode = System.Net.HttpStatusCode.InternalServerError,
        //            Message = ex.Message,
        //        };
        //        return StatusCode((int)System.Net.HttpStatusCode.InternalServerError, responseMessage);
        //    }
        //}


        [AllowAnonymous]
        [HttpPost]
        public IActionResult ForgotPassword(ForgotPasswordRequestDto forgotPassRequest)
        {
            var Response = _authenticateService.ForgotPassword(forgotPassRequest);
            return Ok(Response);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult VerifyForgotPassword(VerifyPasswordReqDto verifyPasswordReq)
        {
            if (string.IsNullOrEmpty(verifyPasswordReq.Password))
            {
                return BadRequest("Invalid request");
            }
            var response = _authenticateService.VerifyForgotPassword(verifyPasswordReq);
            return Ok(response);
        }
      
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddParent(AddParentDto obj)
        {
            responseDto = _authenticateService.AddParent(obj);
            return Ok(responseDto);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetCovidAssesmentQuestions()
        {
            return Ok(_authenticateService.GetCovidAssesmentQuestions());
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult PostCovidAssesmentAnswers(List<Covid19_Assesment_Answers> obj)
        {
            responseDto = _authenticateService.PostCovidAssesmentAnswers(obj);
            return Ok(responseDto);
        }

        [HttpPost]
        [Route("AddTeacher")]
        public IActionResult AddTeacher(TeacherRequestDto obj)
        {
            responseDto = _authenticateService.AddTeacher(obj);
            return Ok(responseDto);
        }
    }
}