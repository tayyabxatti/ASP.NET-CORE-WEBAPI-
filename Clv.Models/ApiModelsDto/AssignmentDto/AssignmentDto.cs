using Clv.Models.Entities.AssignmentEntity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class AssignmentDto
    {
        [Key]
        public int AssignmentID { get; set; }

        [Required(ErrorMessage ="Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        public int TotalMarks { get; set; }
        public int Pod_ID { get; set; }
        [Required(ErrorMessage = "Assigned Date is required")]
        public DateTime AssignedOn { get; set; }
        [Required(ErrorMessage = "Last Date is required")]
        public DateTime LastDate { get; set; }
        
        public List<FileDto> Files { get; set; }
    }
}
