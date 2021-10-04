using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.GradeLevelDto
{
    public class GradeLevelListDto
    {
        [Key]
        public int GradeLevelID { get; set; }
        public string Name { get; set; }
    }
}
