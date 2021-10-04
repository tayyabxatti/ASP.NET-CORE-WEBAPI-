using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.Subject
{
    public class SubjectDto
    {
        [Key]
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; }
    }
}
