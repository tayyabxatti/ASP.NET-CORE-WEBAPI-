using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.PodStudentDto
{
    public class PodGetDto
    {
        [Key]
        public int PodID { get; set; }
        public byte[] Avatar { get; set; }
        public string TeacherName { get; set; }
        public string SubjectName { get; set; }
        public string Location { get; set; }
        public string LearningStyle { get; set; }
    }
}
