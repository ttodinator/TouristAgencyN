using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Like
    {
        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
    }
}
