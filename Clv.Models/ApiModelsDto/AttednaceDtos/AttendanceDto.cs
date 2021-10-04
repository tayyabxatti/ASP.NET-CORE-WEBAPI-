using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.AttednaceDtos
{
    public class AttendanceDto
    {
        public int PodID { get; set; }
        public List<AttendanceRequest> AttendanceRequests { get; set; }
        public AttendanceDto()
        {
            AttendanceRequests = new List<AttendanceRequest>();
        }
    }
    public class AttendanceRequest
    {
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Pod_ID { get; set; }
        public int Student_ID { get; set; }
    }
}
