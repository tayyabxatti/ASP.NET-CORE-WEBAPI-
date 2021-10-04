using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.PodStudentDto
{
    public class PodStudentsDto
    {
        [Key]
        public int RollNo { get; set; }
        public byte[] Avatar { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsCovidQuestionComplted { get; set; }
        public string FatherName { get; set; }
    }
}
