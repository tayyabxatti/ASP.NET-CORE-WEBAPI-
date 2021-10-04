using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.TeacherDtos
{
    public class TeacherStatusDto
    {
        [Required(ErrorMessage ="Teacher id is required")]
        public int TeacherId { get; set; }
        [Required(ErrorMessage = "Status is required")]
        public string Status { get; set; }
    }
}
