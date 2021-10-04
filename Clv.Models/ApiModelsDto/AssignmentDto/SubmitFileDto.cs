using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class SubmitFileDto
    {
        public byte[] File { get; set; }
        public string Extension { get; set; }
        public string ContentType { get; set; }
    }
}
