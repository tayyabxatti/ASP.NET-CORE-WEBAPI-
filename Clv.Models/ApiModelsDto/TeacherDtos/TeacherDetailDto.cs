using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.TeacherDtos
{
    public class TeacherDetailDto
    {
        [Key]
        public int TeacherID { get; set; }
        public bool IsProfileCompleted { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string State { get; set; }
        public string DOB { get; set; }
        public string ZipCode { get; set; }
        public string WillingTotravel { get; set; }
        public string Pod_Secondary_Language { get; set; }
        public string Pod_Primary_Language { get; set; }
        public string Certification_Status { get; set; }
        public string Preferred_Grade_Level { get; set; }
        public string Teaching_skills { get; set; }
        public int UserId { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }

    }
}
