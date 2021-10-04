using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.PodStudentDto
{
    public class PodEditDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Tag { get; set; }

        [Key]
        [Required(ErrorMessage ="Pod id is required")]
        public int PodID { get; set; }
        public int Teacher_ID { get; set; }
        public int Subject_ID { get; set; }
        public int LearningStyle_ID { get; set; }
    }
}
