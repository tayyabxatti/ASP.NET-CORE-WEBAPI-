﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.TeacherEntity
{
    [Table("tbl_TeacherCv")]
    public class TeacherCv
    {
        [Key]
        public int TeacherCvID { get; set; }
        public string FileName { get; set; }
        public byte[] Content { get; set; }
    }
}
