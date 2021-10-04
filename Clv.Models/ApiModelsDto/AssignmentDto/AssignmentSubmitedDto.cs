using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class AssignmentSubmitedDto
    {
        [Key]
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Avatar { get; set; }
        public DateTime SubmitedDate { get; set; }
        public byte[] Data { get; set; }

    }
}
