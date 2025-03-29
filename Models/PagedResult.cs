using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmadeusAPI.Models
{
    public class PagedResult <T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
    }
}