using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.SpecialNeedDto
{
    public class SpecialNeedRequestDto
    {
        [Required(ErrorMessage = "Special need is required")]
        public string Name { get; set; }
    }
}
