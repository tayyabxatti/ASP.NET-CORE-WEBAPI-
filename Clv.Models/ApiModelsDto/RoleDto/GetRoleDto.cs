using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.RoleDto
{
    public class GetRoleDto
    {
        [Key]
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
