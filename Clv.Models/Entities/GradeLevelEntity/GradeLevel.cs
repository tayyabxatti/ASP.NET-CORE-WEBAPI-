using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.GradeLevelEntity
{
    [Table("tbl_GradeLevel")]
    public class GradeLevel
    {
        [Key]
        public int GradeLevelID { get; set; }
        public string Name { get; set; }
    }
}
