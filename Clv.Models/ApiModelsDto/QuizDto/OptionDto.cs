using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class OptionDto
    {
        public int QuizQuestionOptionID { get; set; }
        public int QuizQuestions_ID { get; set; }
        public bool IsCorrectOption { get; set; }
        public string Option { get; set; }
    }
}
