using Clv.Models.Entities.QuizEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizRequestSubmitDto
    {
        [Key]
        public int QuizSubmitedID { get; set; }
        public int Student_ID { get; set; }
        public int Quiz_ID { get; set; }
        public DateTime SubmitedDate { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public List<QuizSubmitedDetail> quizSubmitedDetails { get; set; }
    }
}
