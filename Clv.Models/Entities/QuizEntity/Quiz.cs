using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.QuizEntity
{
    [Table("tbl_Quiz")]
    public class Quiz
    {
        public int QuizID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalMarks { get; set; }
        public DateTime EndTime { get; set; }
        public bool IsActive { get; set; }
        public int Pod_ID { get; set; }
    }
}
