using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.ApiModelsDto.ResponseDto
{
    public class Response
    {
        public bool Success { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
    }
}
