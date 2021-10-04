using System.ComponentModel.DataAnnotations;

namespace Clv.Models.ApiModels.AuthenticateDto
{
    public class LoginDto
    {
        [Required]
        [StringLength(100, MinimumLength = 4)]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 4)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }

    public class UserTokenDto
    {
        public string Token { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public string ErrorMessage { set; get; }
        public int LoginUserID { set; get; }
        public int ParentID { set; get; }
    }
    public class RegisterResp
    {
        public string Message { get; set; }
        public string Status { get; set; }
    }

    public class AssociatedUserIDDto
    {
        [Key]
        public int AssociatedId { get; set; }
    }
    public class ProfileIsCompleteDto
    {
        [Key]
        public bool IS_COMPLETED { get; set; }
        public bool IsVerified { get; set; }
    }
}
