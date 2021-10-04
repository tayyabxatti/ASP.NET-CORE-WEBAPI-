using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities
{
    [Table("tbl_SpecialNeed")]
    public class SpecialNeed
    {
        [Key]
        public int SpecialNeedID { get; set; }
        public string Name { get; set; }
    }
}
