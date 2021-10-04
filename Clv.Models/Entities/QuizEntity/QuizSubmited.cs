using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.QuizEntity
{
    [Table("tbl_QuizSubmited")]
    public class QuizSubmited
    {
        [Key]
        public int QuizSubmitedID { get; set; }
        public int Student_ID { get; set; }
        public int Quiz_ID { get; set; }
        public string Status { get; set; }
        public DateTime SubmitedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
