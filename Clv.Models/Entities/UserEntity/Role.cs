using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.UserEntity
{
    [Table("tbl_Role")]
    public class Role
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    }
}