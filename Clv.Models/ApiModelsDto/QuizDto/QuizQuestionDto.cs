using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizQuestionDto
    {
        public QuizQuestionDto()
        {
            OptionDto = new List<QuizQuestionOptionDto>();
        }
        public int QuizQuestionID { get; set; }
        public int Quiz_ID { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public List<QuizQuestionOptionDto> OptionDto { get; set; }
    }
}
