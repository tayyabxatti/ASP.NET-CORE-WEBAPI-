using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizDetailDto
    {
        public QuizDetailDto()
        {
            QuestionDtos = new List<QuestionDto>();
        }
        public int QuizID { get; set; }
        public string Title { get; set; }
        public string Decription { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime StartTime { get; set; }
        public int TotalMarks { get; set; }
        public DateTime EndTime { get; set; }
        public string Question { get; set; }
        public int Question_ID { get; set; }
        public int OptionID { get; set; }
        public bool IsActive { get; set; }
        public List<QuestionDto> QuestionDtos { get; set; }

    }
}
