using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities
{
    [Table("tbl_Subject")]
    public class Subject
    {
        [Key]
        public int SubjectID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public string SubjectName { get; set; }
    }
}
