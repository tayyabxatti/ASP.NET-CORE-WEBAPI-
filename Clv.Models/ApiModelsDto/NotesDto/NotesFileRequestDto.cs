using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.NotesDto
{
    public class NotesFileRequestDto
    {
        public byte[] Data { get; set; }
        [Required(ErrorMessage = "File Name  is required")]
        public string FileName { get; set; }
        [Required(ErrorMessage = "File Extension  is required")]
        public string Extension { get; set; }
        [Required(ErrorMessage = "Content Type  is required")]
        public string ContentType { get; set; }
    }
}
