using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace Clv.Models.ApiModelsDto.AuthDto
{

    public class ForgotPasswordRequestDto
    {
        [Required]
        public string Email { get; set; }
    }
    public class ForgotPasswordResDto
    {
        public bool Success { set; get; }
        public string Message { get; set; }
    }

    public class VerifyPasswordReqDto
    {
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
