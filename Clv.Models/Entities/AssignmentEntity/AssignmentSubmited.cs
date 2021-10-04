using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.AssignmentEntity
{
    [Table("tbl_AssignmentSubmited")]
    public class AssignmentSubmited
    {
        public int AssignmentSubmitedID { get; set; }
        public int TotalMarks { get; set; }
        public int Assignment_ID { get; set; }
        public int Student_ID { get; set; }
        public DateTime SubmitedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public byte[] File { get; set; }
    }
}
