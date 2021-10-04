using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.Subject
{
    public class SubjectRequestDto
    {
        [Required(ErrorMessage ="Suject name is required")]
        public string SubjectName { get; set; }
        public int CreatedBy { get; set; }
        public bool isActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
