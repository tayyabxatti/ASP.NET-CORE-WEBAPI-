using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto
{
    public class CustomFileValidator : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                byte[] filedata = (byte[])value;

                int place = Convert.ToInt32(Math.Floor(Math.Log(filedata.Length, 1024)));

                if (place > 2)
                {
                    return new ValidationResult("Please Enter a Valid Email.");
                }
                else
                {
                    return ValidationResult.Success;
                }
            }
            else
            {
                return new ValidationResult("" + validationContext.DisplayName + " is required");
            }
        }
    }
}