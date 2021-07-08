using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na sobu
    /// </summary>
    public class Room
    {
        public int Id { get; set; }
        public string Name { get; set; }
        /// <summary>
        /// Lista svih destinacija koje poseduju odredjeni tip sobe
        /// </summary>
        public List<DestinationRooms> Rooms { get; set; }

        public Room()
        {

        }

        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
