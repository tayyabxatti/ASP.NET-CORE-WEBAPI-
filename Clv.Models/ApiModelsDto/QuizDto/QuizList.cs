using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizList
    {
        [Key]
        public int QuizID { get; set; }
        public string Title { get; set; }
        public int TotalMarks { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
