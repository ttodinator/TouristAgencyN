using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class DestinationParams : PaginationParams
    {
        public string CurrentDestination { get; set; }
        public string Type { get; set; } = "all";
        public double minPrice { get; set; } = 1;
        public double maxPrice { get; set; } = 1000;
        public string OrderBy { get; set; } = "dateAdded";
    }
}
