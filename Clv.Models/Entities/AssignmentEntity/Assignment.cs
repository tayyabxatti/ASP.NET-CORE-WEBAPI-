using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.AssignmentEntity
{
    [Table("tbl_Assignment")]
    public class Assignment
    {
        public int AssignmentID { get; set; }
        public int TotalMarks { get; set; }
        public int Pod_ID { get; set; }
        public DateTime AssignedOn { get; set; }
        public DateTime LastDate { get; set; }
        public bool IsActive { get; set; }
        public byte[] File { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
