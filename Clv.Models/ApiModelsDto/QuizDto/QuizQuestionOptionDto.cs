using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizQuestionOptionDto
    {
        public int QuizQuestions_ID { get; set; }
        public bool IsCorrectOption { get; set; }
        public string Option { get; set; }
    }
}
