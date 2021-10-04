using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.NotesEntity
{
    [Table("tbl_NotesFile")]
    public class NotesFile
    {
        [Key]
        public int NotesFileId { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
        public int Notes_ID { get; set; }
    }
}
