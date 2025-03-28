using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go4it_amadeus.Models.Response
{
    public class AdminAuthResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public DateTime Expiration { get; set; }
        public string? ErrorMessage { get; set; }
    }
}
