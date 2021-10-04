using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.QuizEntity
{
    [Table("tbl_QuizSubmitedDetail")]
    public class QuizSubmitedDetail
    {
        [Key]
        public int QuizSubmitDetailID { get; set; }
        public int QuizSubmited_ID { get; set; }
        public int Question_ID { get; set; }
        public int QuesionOption_ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
