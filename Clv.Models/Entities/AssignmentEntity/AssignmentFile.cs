using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Clv.Models.Entities.AssignmentEntity
{
    [Table("tbl_AssignmentFile")]
    public class AssignmentFile
    {
            public int AssignmentFileID { get; set; }
            public int Assignment_ID { get; set; }
            public byte[] Data { get; set; }
            public string FileExt { get; set; }
            public string ContectType { get; set; }
    }
}
