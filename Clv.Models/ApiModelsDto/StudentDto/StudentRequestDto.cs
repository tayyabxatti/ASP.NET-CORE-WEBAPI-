using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.StudentDto
{
    public class StudentRequestDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        //[RegularExpression("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9]).{8,}$", ErrorMessage = "At least one upper Letter, One lower Letter & atleast One digit")]
        public string Password { get; set; }
        public int ImgeFile_ID { get; set; }
        public int Parent_ID { get; set; }
        public string GradeLevel_ID { get; set; }
        public string SpecialNeed_ID { get; set; }
        public string Subject_ID { get; set; }
        public string LearningStyle_ID { get; set; }
    }
}
