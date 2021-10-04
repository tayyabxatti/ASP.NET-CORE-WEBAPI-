using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.ParentsDto
{
    public class ParentDetailDto
    {
        [Key]
        public int UserId { get; set; }
        public int ParentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsProfileCompleted { get; set; }
        public string CovidStatus { get; set; }
        public string Country  { get; set; }
        public string City { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public int TotalMarks { get; set; }
        public int ObtainMarks { get; set; }

    }
}
