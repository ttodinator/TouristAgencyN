using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class DestinationRooms
    {
        public int DestinationId { get; set; }
        public Destination Destination { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }

        public DestinationRooms()
        {

        }

        public DestinationRooms(int destinationId, int roomId)
        {
            DestinationId = destinationId;
            RoomId = roomId;
        }
    }
}
