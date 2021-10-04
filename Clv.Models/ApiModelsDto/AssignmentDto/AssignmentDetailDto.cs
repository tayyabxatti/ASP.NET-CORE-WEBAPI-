using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class AssignmentDetailDto
    {
        [Key]
        //public int AssignmentID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int TotalSubmission { get; set; }
        public DateTime AssignedOn { get; set; }
        public DateTime LastDate { get; set; }
        public List<FileDto> files { get; set; }

    }
}
