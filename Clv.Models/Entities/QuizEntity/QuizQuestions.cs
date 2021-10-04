using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.QuizEntity
{
    [Table("tbl_QuizQuestions")]
    public class QuizQuestions
    {
        public int QuizQuestionsID { get; set; }
        public int Quiz_ID { get; set; }
        public string QuestionType { get; set; }
        public string Question { get; set; }
    }
}
