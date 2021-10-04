using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clv.Models.Entities.UserEntity
{
    [Table("tbl_User")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public int RoleId { get; set; }

        public bool IsVerified { get; set; }
        public bool IsProfileCompleted{ get; set; }
        //public string Country { get; set; }
        //public string City { get; set; }
        //public string State { get; set; }
        //public string Street { get; set; }
        //public DateTime? DateOfBirth { get; set; }
        //public string ZipCode { get; set; }
        ////public int TeacherCvId { get; set; }

        //public string Willing_To_Travel { get; set; }
        //public string Pod_Primary_Lang { get; set; }
        //public string Pod_Sec_Lang { get; set; }
        //public string Certification_Status { get; set; }
        //public string Preffered_Grade_Level { get; set; }
        //public string Special_Teaching_Skills { get; set; }

        public byte[] Avatar { get; set; }
        ////public int TeacherCvId { get; set; }
        //public bool IsVerified { get; set; }
        ////New
        //public byte[] UploadCV { get; set; }
        //public bool ParentStatus { get; set; }
        //public string CaregiverStatus { get; set; }
        //public string PodLearningEnvironment { get; set; }

    }
}

