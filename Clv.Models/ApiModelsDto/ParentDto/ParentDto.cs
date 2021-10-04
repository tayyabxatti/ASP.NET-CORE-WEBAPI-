using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.ParentDto
{
    public class AddParentDto
    {
        //[Required]
        public string Country { get; set; }
        //[Required]
        public string City { get; set; }
        //[Required] 
        public string State { get; set; }
        //[Required] 
        public string Street { get; set; }
        //[Required] 
        public string DOB { get; set; }
        //[Required]
        public string ZipCode { get; set; }
        //[Required] 
        public string Pod_Primary_Language { get; set; }
        //[Required] 
        public string Pod_Secondary_Language { get; set; }
        //[Required] 
        public string Parent_Status { get; set; }
        //[Required] 
        public string Caregiver_Status { get; set; }
        //[Required] 
        public string Pod_Learning_Environment { get; set; }
        public int Profile_Image { get; set; }
        //[Required] 
        public int UserId { get; set; }
       
        //public int Parent_ID { get; set; }
        //public string Status { get; set; }
    }
}
