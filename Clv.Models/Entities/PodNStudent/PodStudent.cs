using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.PodNStudent
{
    [Table("tbl_PodStudent")]
    public class PodStudent
    {
        public int PodStudentID { get; set; }
        public int Pod_ID { get; set; }
        public int Student_ID { get; set; }
        public bool IsActive { get; set; }
    }
}
