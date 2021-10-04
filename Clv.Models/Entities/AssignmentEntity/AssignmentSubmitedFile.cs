using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.AssignmentEntity
{
    [Table("tbl_AssignmentSubmitedFile")]
    public class AssignmentSubmitedFile
    {
        [Key]
        public int SubmitFileID { get; set; }
        public int AssignmentSubmited_ID { get; set; }
        public byte[] Data { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
    }
}
