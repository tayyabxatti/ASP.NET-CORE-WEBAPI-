using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.SpecialNeedDto
{
    public class SpecialNeedListDto
    {
        [Key]
        public int SpecialNeedID { get; set; }
        public string Name { get; set; }
    }
}
