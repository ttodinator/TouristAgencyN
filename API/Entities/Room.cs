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
        /// <summary>
        /// jedinstveni identifikator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// ime vrste sobe
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Lista svih destinacija koje poseduju odredjeni tip sobe
        /// </summary>
        public List<DestinationRooms> Rooms { get; set; }
        /// <summary>
        /// prazan konstruktor
        /// </summary>
        public Room()
        {

        }
        /// <summary>
        /// konstruktor sa parametrima
        /// </summary>
        /// <param name="id">jedinstveni identifikator</param>
        /// <param name="name">naziv vrste sobe</param>

        public Room(int id, string name)
        {
            Id = id;
            Name = name;
        }
        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string sa podacima o sobi</returns>
        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
