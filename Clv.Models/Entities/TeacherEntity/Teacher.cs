using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.TeacherEntity
{
    [Table("tbl_Teacher")]
    public class Teacher
    {
        [Key]
        public int TeacherID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public DateTime DOB { get; set; }
        public string ZipCode { get; set; }
        public string WillingTotravel { get; set; }
        public string Pod_Secondary_Language { get; set; }
        public string Pod_Primary_Language { get; set; }
        public string Certification_Status { get; set; }
        public string Preferred_Grade_Level { get; set; }
        public string Teaching_skills { get; set; }
        public int Teachercv_ID { get; set; }
        public int Profile_Image { get; set; }
        public int UserId { get; set; }
    }
}
