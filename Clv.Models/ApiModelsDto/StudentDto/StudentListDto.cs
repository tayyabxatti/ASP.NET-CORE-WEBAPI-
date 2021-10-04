using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.StudentDto
{
    public class StudentListDto
    {
        [Key]
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string SubjectName { get; set; }
        public string Title { get; set; }
        public string GradeLevel { get; set; }
        public string SpecialNeed { get; set; }
        public string Image_Name { get; set; }
        public byte[] Content { get; set; }
    }
}
