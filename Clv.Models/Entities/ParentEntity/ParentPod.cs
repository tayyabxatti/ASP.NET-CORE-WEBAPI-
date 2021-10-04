using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.ParentEntity
{
    [Table("tbl_ParentPod")]
    public class ParentPod
    {
        [Key]
        public int Pod_ID { get; set; }
        public int Parent_ID { get; set; }
        public string Pod_Primary_Language { get; set; }
        public string Pod_Secondary_Language { get; set; }
        public string Parent_Status { get; set; }
        public string Caregiver_Status { get; set; }
        public string Pod_Learning_Environment { get; set; }
        public string Status { get; set; }
    }
}
