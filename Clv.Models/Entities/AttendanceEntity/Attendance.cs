using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.AttendanceEntity
{
    [Table("tbl_Attendance")]
    public class Attendance
    {
        public int AttendanceID { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public int UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Pod_ID { get; set; }
        public int Student_ID { get; set; }

    }
}
