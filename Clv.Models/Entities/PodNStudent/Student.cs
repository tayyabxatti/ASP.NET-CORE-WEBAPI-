using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.PodNStudent
{
    [Table("tbl_Student")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public int ImgeFileID { get; set; }
        public bool IsActive { get; set; }
        public int Parent_ID { get; set; }
        public int GradeLevel_ID { get; set; }
        public int SpecialNeed_ID { get; set; }
        public int Subject_ID { get; set; }
        public int LearningStyle_ID { get; set; }
        public int User_Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
