using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.QuizEntity
{
    [Table("tbl_QuizQuestionOption")]
    public class QuizQuestionOption
    {
        public int QuizQuestionOptionID { get; set; }
        public int QuizQuestions_ID { get; set; }
        public bool IsCorrectOption { get; set; }
        public string Option { get; set; }
    }
}
