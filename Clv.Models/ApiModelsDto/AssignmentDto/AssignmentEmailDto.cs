using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.AssignmentDto
{
    public class AssignmentEmailDto
    {
        public string Title { get; set; }
        public DateTime AssignedOn { get; set; }
        public DateTime LastDate { get; set; }
        public string SubjectName { get; set; }
        public string StudentName { get; set; }
        public string FatherName { get; set; }
        public string StudentEmail { get; set; }
        public string ParentEmail { get; set; }
    }
}
