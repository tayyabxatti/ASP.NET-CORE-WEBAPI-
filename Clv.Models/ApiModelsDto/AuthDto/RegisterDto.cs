using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Clv.Models.ApiModelsDto.AuthDto
{
    public class RegisterDto
    {

        /// <summary>
        /// UserName
        /// </summary>
        /// <value>UserName</value>
        //[Required]
        //[DataMember(Name = "UserName")]
        //[StringLength(64, MinimumLength = 3)]
        //public string UserName { get; set; }

        /// <summary>
        /// FirstName
        /// </summary>
        /// <value>FirstName</value>
        [Required]
        [DataMember(Name = "FirstName")]
        [StringLength(32, MinimumLength = 3)]
        public string FirstName { get; set; }

        /// <summary>
        /// LastName
        /// </summary>
        /// <value>LastName</value>
        [Required]
        [DataMember(Name = "LastName")]
        [StringLength(32, MinimumLength = 3)]
        public string LastName { get; set; }

        /// <summary>
        /// Email to valid  user
        /// </summary>
        /// <value>Email to valid  user</value>
        [Required]
        [DataMember(Name = "Email")]
        [StringLength(64, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Email to valid  user
        /// </summary>
        /// <value>Email to valid  user</value>
        [Required]
        [DataMember(Name = "Email")]
        [StringLength(64, MinimumLength = 3)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string ConfirmEmail { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        /// <value>Password</value>
        [Required]
        [DataMember(Name = "Password")]
        [StringLength(32, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Include at least one number and one symbol.")]
        public string Password { get; set; }

        [Required]
        [DataMember(Name = "Password")]
        [StringLength(32, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}", ErrorMessage = "Include at least one number and one symbol.")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string UserType { get; set; }

        //public string ClassId { get; set; }
        //public string Profession{ get; set; }
        //public string DegreeLevel{ get; set; }
        //public string Institution{ get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class RegisterDto {\n");
            //sb.Append("  FirstName: ").Append(FirstName).Append("\n");
            //sb.Append("  LastName: ").Append(LastName).Append("\n");
            sb.Append("  Email: ").Append(Email).Append("\n");
            sb.Append("  Password: ").Append(Password).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((RegisterDto)obj);
        }

        /// <summary>
        /// Returns true if RegisterDto instances are equal
        /// </summary>
        /// <param name="other">Instance of RegisterDto to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(RegisterDto other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return

                (
                    Email == other.Email ||
                    Email != null &&
                    Email.Equals(other.Email)
                ) &&
                (
                    Password == other.Password ||
                    Password != null &&
                    Password.Equals(other.Password)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)

                if (Email != null)
                    hashCode = hashCode * 59 + Email.GetHashCode();
                if (Password != null)
                    hashCode = hashCode * 59 + Password.GetHashCode();
                return hashCode;
            }
        }
    }
}
