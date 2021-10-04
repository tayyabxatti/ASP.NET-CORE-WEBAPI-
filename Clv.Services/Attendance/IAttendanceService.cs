using Clv.Models.ApiModelsDto.AttednaceDtos;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Services.Attendance
{
    public interface IAttendanceService
    {
        Response Create(AttendanceDto attendanceDto);
        Response UpdateAttendance(AttendanceDto attendanceDto);
    }
}
