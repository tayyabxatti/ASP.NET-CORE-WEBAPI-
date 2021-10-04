using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class FileDto
    {
        [Key]
        [Required(ErrorMessage ="Upload file is required")]
        [CustomFileValidator]
        public byte[] File { get; set; }
        [Required(ErrorMessage = "File extension is required")]
        public string Extension { get; set; }
        [Required(ErrorMessage = "ContentType is required")]
        public string ContentType { get; set; }
    }
}

