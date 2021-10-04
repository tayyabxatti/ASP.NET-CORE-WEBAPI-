using Clv.Core.Uow;
using Clv.Models.ApiModelsDto.AttednaceDtos;
using Clv.Models.ApiModelsDto.ResponseDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Clv.Services.Attendance
{
    public class AttendanceService : IAttendanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        Response responseDtos;

        public AttendanceService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Response Create(AttendanceDto request)
        {
            try
            {
                var repository = _unitOfWork.GetRepository<Models.Entities.AttendanceEntity.Attendance>();

                var attend = repository.GetAll().Where(c => c.Pod_ID == request.PodID && c.CreatedDate == DateTime.Now.Date).FirstOrDefault();
                if (attend != null)
                {
                    return responseDtos = new Response()
                    {
                        StatusCode = "401",
                        Message = "Attendance already exist"
                    };
                }

                List<Models.Entities.AttendanceEntity.Attendance> attendanceList = new List<Models.Entities.AttendanceEntity.Attendance>();

                foreach (var attendance in request.AttendanceRequests)
                {
                    attendanceList.Add(new Models.Entities.AttendanceEntity.Attendance()
                    {
                        Status = attendance.Status,
                        CreatedBy = attendance.CreatedBy,
                        CreatedDate = DateTime.Now,
                        Pod_ID = attendance.Pod_ID
                    });
                }
                //repository.AddRanges(attendanceList);
                _unitOfWork.Commit();
                return responseDtos = new Response()
                {
                    StatusCode = "200",
                    Message = "Attendance has been submitted successfully"
                };
            }
            catch (Exception ex)
            {
                return responseDtos = new Response()
                {
                    StatusCode = "Error",
                    Message = "Some thing wrong please try again later"
                };
            }
        }


        public Response UpdateAttendance(AttendanceDto attendanceDto)
        {
            throw new NotImplementedException();
        }
    }
}
