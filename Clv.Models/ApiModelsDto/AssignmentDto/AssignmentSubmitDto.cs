using Clv.Models.Entities.AssignmentEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class AssignmentSubmitDto
    {
        [Key]
        public int AssignmentSubmitedID { get; set; }
        public int TotalMarks { get; set; }
        public int Assignment_ID { get; set; }
        public int Student_ID { get; set; }
        public string SubmitStatus { get; set; }

        public List<SubmitFileDto> Files { get; set; }
    }
}
