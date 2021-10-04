using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizRequestDto
    {
        [Key]
        public int Pod_ID { get; set; }
        //public int QuizID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int TotalMarks { get; set; }
       
        public List<QuizQuestionDto> quizQuestionDtosList { get; set; }
     
    }
}
