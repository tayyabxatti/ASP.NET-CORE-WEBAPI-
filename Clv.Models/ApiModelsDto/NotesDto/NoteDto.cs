using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.NotesDto
{
    public class NoteDto
    {
        [Key]

        public int NotesID { get; set; }
        public string Description { get; set; }
        public int Pod_ID { get; set; }
        public DateTime CreateDate { get; set; }
        public string SubjectName { get; set; }
        public byte[] Data { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }

    }
}
