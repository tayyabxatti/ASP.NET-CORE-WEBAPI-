using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.POD
{
    public class PendingPodDto
    {
        [Key]
        public int ParentPodID { set; get; }
        public int Parent_ID { set; get; }
        public string Pod_Primary_language { set; get; }
        public string Pod_Secondary_language { set; get; }
        public string Parent_Status { set; get; }
        public string Caregiver_Status { set; get; }
        public string Pod_Learning_Environment { set; get; }
        public string Status { set; get; }
        public byte[] Content { set; get; }
    }
}
