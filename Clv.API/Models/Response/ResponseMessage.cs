using System;
using System.Collections.Generic;
using System.Text;

namespace Clv.Models.Response
{
    public class ResponseMessage
    {
        public string Message { get; set; }
        public System.Net.HttpStatusCode HttpStatusCode { get; set; }
    }
}
