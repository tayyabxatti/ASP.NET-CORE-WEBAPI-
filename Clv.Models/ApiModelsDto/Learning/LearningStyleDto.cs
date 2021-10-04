using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.Learning
{
    public class LearningStyleDto
    {
        [Key]
        public int LearningStyleID { get; set; }
        public string Title { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
    }
}
