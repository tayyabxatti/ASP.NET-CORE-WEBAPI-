using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.TeacherDtos
{
    public class TeacherRequestDto
    {
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public DateTime DOB { get; set; }
        public string ZipCode { get; set; }
        public string WillingTotravel { get; set; }
        public string Pod_Secondary_Language { get; set; }
        public string Certification_Status { get; set; }
        public string Preferred_Grade_Level { get; set; }
        public int TeacherCvId { get; set; }
        public int Profile_Image { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        
    }
}
