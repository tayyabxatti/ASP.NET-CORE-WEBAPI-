using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities
{
    [Table("tbl_LearingStyle")]
    public class LearingStyle
    {
        [Key]
        public int LearningStyleID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public string Title { get; set; }
    }
}
