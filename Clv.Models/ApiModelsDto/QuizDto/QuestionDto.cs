using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuestionDto
    {
        public QuestionDto()
        {
            OptionDtos = new List<OptionDto>();
        }
        public int QuizQuestionsID { get; set; }
        public int Quiz_ID { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
        public List<OptionDto> OptionDtos { get; set; }
    }
}
