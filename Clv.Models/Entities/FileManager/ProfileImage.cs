using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.FileManager
{
    [Table("tbl_Profile_Image")]
    public class ProfileImage
    {
        [Key]
        public int Profile_Image_Id { get; set; }
        public string Image_Name { get; set; }
        public byte[] Content { get; set; }
    }
}
