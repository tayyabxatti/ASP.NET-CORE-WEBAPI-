using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.PodStudentDto
{
    public class AssignmentListDto
    {
        [Key]
        //public int PodID { get; set; }
        public string Title { get; set; }
        public DateTime AssignedOn { get; set; }
        public DateTime LastDate { get; set; }
    }
}

