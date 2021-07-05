using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<DestinationRooms> Rooms { get; set; }
    }
}
