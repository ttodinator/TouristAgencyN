using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Asocijativna klasa koja sluzi za povezivanje soba i destinacija
    /// </summary>
    public class DestinationRooms
    {
        /// <summary>
        /// jedinstveni identifikator destinacije
        /// </summary>
        public int DestinationId { get; set; }
        /// <summary>
        /// destinacija
        /// </summary>
        public Destination Destination { get; set; }
        /// <summary>
        /// jedinstveni identifikator sobe
        /// </summary>
        public int RoomId { get; set; }
        /// <summary>
        /// soba
        /// </summary>
        public Room Room { get; set; }

        /// <summary>
        /// prazan kosntruktor
        /// </summary>
        public DestinationRooms()
        {

        }

        /// <summary>
        /// konstruktpr sa parametrima
        /// </summary>
        /// <param name="destinationId">jedinstveni identifikator destinacije</param>
        /// <param name="roomId">jedinstveni identifikator sobe</param>

        public DestinationRooms(int destinationId, int roomId)
        {
            DestinationId = destinationId;
            RoomId = roomId;
        }
    }
}
