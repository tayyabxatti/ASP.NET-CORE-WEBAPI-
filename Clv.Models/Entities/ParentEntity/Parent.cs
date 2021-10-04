using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.ParentEntity
{
    [Table("tbl_Parent")]
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Street { get; set; }
        public string DOB { get; set; }
        public string ZipCode { get; set; }
        //public string Pod_Primary_Language { get; set; }
        //public string Pod_Secondary_Language { get; set; }
        //public string Parent_Status { get; set; }
        //public string Caregiver_Status { get; set; }
        //public string Pod_Learning_Environment { get; set; }
        public int Profile_Image { get; set; }
        public int UserId { get; set; }
    }
}
