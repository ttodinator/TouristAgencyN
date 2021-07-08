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

        public Like()
        {
                
        }

        public Like(int appUserId, int destinationId)
        {
            AppUserId = appUserId;
            DestinationId = destinationId;
        }

        public override string ToString()
        {
            return $"{AppUserId} {DestinationId}";
        }


    }
}
