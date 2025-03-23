using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace go4it_amadeus.Models.Exception
{
    public class IMistakeResponse
    {
        int StatusCode { get; set; }
        string Message { get; set; }

        string Details { get; set; }

    }
}