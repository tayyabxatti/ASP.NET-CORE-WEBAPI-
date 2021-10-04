using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.ComponentModel.DataAnnotations;
namespace Clv.Models.Entities.Covid_19_Assesment_Entity
{
    [Table("tbl_Covid_Assesment")]

    public class Covid_Assesment
    {
        [Key]
        public int Covid_Question_ID { get; set; }
        public string Question_Description { get; set; }
    }
    
    
    [Table("tbl_User_Covid_Assesment")]
    public class User_Covid_Assesment
    {
        [Key]
        public int User_Covid_Assesment_Id { get; set; }
        public int UserId { get; set; }
        public int Covid_Question_Id { get; set; }
        public bool Is_Answer_True { get; set; }
    }
}
