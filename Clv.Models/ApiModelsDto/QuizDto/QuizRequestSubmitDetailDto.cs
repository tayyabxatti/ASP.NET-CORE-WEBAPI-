using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.QuizDto
{
    public class QuizRequestSubmitDetailDto
    {
        [Key]
        public int QuizSubmitDetailID { get; set; }
        public int Question_ID { get; set; }
        public int QuesionOption_ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
