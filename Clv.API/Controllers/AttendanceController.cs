using Clv.Models.ApiModelsDto.AttednaceDtos;
using Clv.Models.ApiModelsDto.ResponseDto;
using Clv.Services.Attendance;
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
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;
        private Response respnse;
        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }

        [HttpPost]
        public IActionResult Create(AttendanceDto attendanceDto)
        {
            respnse = _attendanceService.Create(attendanceDto);

            if (respnse.StatusCode == "200")
                return Ok(respnse);

            if (respnse.StatusCode == "401")
                return Unauthorized(respnse);

            else
                return StatusCode(501, respnse);
        }
    }
}
