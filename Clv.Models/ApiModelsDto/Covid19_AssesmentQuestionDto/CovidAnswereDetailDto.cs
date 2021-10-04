using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Clv.Models.ApiModelsDto.Covid19_AssesmentQuestionDto
{
    public class CovidAnswereDetailDto
    {
        [Key]
        public string Question_Description { get; set; }
        public bool Answere { get; set; }
    }
}
