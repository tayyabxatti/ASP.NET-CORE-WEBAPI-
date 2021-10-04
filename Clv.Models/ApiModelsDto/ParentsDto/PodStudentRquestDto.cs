using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.ParentsDto
{
    public class PodStudentRquestDto
    {
        [Required(ErrorMessage = "Student id is required")]
        public int StudentID { get; set; }
        [Required(ErrorMessage = "Pod id is required")]
        public int PodID { get; set; }
    }
}
