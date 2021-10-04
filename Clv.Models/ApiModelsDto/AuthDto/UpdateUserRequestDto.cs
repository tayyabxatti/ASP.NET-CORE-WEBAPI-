using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AuthDto
{
    public class UpdateUserRequestDto
    {
        public int UserID { get; set; }
        //[Required]
        //[DataMember(Name = "FirstName")]
        [StringLength(32, MinimumLength = 3)]
        public string FirstName { get; set; }

        //[Required]
        //[DataMember(Name = "LastName")]
        //[StringLength(32, MinimumLength = 3)]
        public string LastName { get; set; }

        //[Required]
        //[DataMember(Name = "Username")]
        //[StringLength(32, MinimumLength = 3)]
        public string Username { get; set; }

        //[Required]
        //[DataMember(Name = "Email")]
        public string Email { get; set; }

        //[Required]
        //[DataMember(Name = "Country")]
        public string Country { get; set; }

        //[Required]
        //[DataMember(Name = "City")]
        public string City { get; set; }

        //[Required]
        //[DataMember(Name = "State")]
        public string State { get; set; }

        //[Required]
        //[DataMember(Name = "Street")]
        public string Street { get; set; }

        //[Required]
        //[DataMember(Name = "ZipCode")]
        public string ZipCode { get; set; }

        //[Required]
        //[DataMember(Name = "DateOfBirth")]
        public DateTime DateOfBirth { get; set; }

        //[Required]
        //[DataMember(Name = "Willing_To_Travel")]
        public string Willing_To_Travel { get; set; }

        //[Required]
        //[DataMember(Name = "Pod_Primary_Lang")]
        public string Pod_Primary_Lang { get; set; }

        //[Required]
        //[DataMember(Name = "Pod_Sec_Lang")]
        public string Pod_Sec_Lang { get; set; }

        //[Required]
        //[DataMember(Name = "Certification_Status")]
        public string Certification_Status { get; set; }

        //[Required]
        //[DataMember(Name = "Preffered_Grade_Level")]
        public string Preffered_Grade_Level { get; set; }

        //[Required]
        //[DataMember(Name = "Special_Teaching_Skills")]
        public string Special_Teaching_Skills { get; set; }


        //[DataMember(Name = "Avatar")]
        public byte[]? Avatar { get; set; }

        //[Required]
        //[DataMember(Name = "TeacherCvId")]
        public int TeacherCvId { get; set; }


        //[Required]
        //[DataMember(Name = "UploadCV")]
        public byte[]? UploadCV { get; set; }

        //[Required]
        //[DataMember(Name = "ParentStatus")]
        public bool ParentStatus { get; set; }

        //[Required]
        //[DataMember(Name = "CaregiverStatus")]
        public string CaregiverStatus { get; set; }

        //[Required]
        //[DataMember(Name = "PodLearningEnvironment")]
        public string? PodLearningEnvironment { get; set; }

    }
}
