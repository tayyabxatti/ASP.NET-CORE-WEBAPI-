using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.NotesEntity
{
    [Table("tbl_Notes")]
    public class Notes
    {
        [Key]
        public int NotesID { get; set; }
        public string Description { get; set; }
        public int Pod_ID { get; set; }
        public DateTime CreateDate { get; set; }
      
    }
}
