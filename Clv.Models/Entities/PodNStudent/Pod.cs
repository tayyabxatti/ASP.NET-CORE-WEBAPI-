using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.PodNStudent
{
    [Table("tbl_Pod")]
    public class POD
    {
        [Key]
        public int PodID { get; set; }
        public int CreatedBy { get; set; }
        public int Teacher_ID { get; set; }
        public int Subject_ID { get; set; }
        public int LearningStyle_ID { get; set; }
        public bool isActive { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }
    
    }
}
