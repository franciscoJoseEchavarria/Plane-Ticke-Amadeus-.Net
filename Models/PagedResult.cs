using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AmadeusAPI.Models
{
    public class PagedResult <T>
    {
        public List<T> Items { get; set; } = new List<T>();
        public int currentPage { get; set; }
        public int pageSize { get; set; }
        public int totalItems { get; set; }
        public int totalPages { get; set; }
    }
}