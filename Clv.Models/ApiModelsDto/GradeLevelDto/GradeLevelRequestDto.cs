using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.GradeLevelDto
{
    public class GradeLevelRequestDto
    {
        [Required(ErrorMessage = "Grade level is required")]
        public string Name { get; set; }
    }
}
