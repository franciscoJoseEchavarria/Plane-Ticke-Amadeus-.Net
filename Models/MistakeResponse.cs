using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using go4it_amadeus.Models.Exception;

namespace AmadeusAPI.Models
{
    public class MistakeResponse: IMistakeResponse
    {
        public string Message { get; set; }
        public string Details { get; set; }
        public int StatusCode { get; set; }
      
    public MistakeResponse(int statusCode, string message, string details)
    {
        StatusCode = statusCode;
        Message = message;
        Details = details;
    }
}
}