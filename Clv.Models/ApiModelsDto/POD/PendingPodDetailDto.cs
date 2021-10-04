using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.POD
{
    public class PendingPodDetailDto
    {
        [Key]
        public int ParentPodID { get; set; }
        public int ParentID { get; set; }
        public string Pod_Primary_Language { get; set; }
        public string Pod_Secondary_Language { get; set; }
        public string Parent_Status { get; set; }
        public string Caregiver_Status { get; set; }
        public string Pod_Learning_Environment { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}
