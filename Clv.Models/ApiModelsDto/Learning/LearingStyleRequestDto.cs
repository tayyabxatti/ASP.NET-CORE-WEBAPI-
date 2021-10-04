using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.Learning
{
    public class LearingStyleRequestDto
    {
        public int LearningStyleID { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool isActive { get; set; }
        public string Title { get; set; }
    }
}
