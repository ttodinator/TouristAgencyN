using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Asocijativna klasa koja sluzi za like-ovanje
    /// </summary>
    public class Like
    {
        /// <summary>
        /// korisnik aplikacije
        /// </summary>
        public AppUser AppUser { get; set; }
        /// <summary>
        /// jedinstveni identifikator korisnika aplikacije
        /// </summary>
        public int AppUserId { get; set; }
        /// <summary>
        /// destinacija
        /// </summary>
        public Destination Destination { get; set; }
        /// <summary>
        /// jedinstveni identifikator destinacije
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        /// prazan konstruktor
        /// </summary>
        public Like()
        {
                
        }

        /// <summary>
        /// konstruktor sa parametrima
        /// </summary>
        /// <param name="appUserId">jedinstveni identifikator korisnika aplikacije</param>
        /// <param name="destinationId">jedinstveni identifikator destinacije</param>
        public Like(int appUserId, int destinationId)
        {
            AppUserId = appUserId;
            DestinationId = destinationId;
        }

        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string sa podacima o like-u</returns>
        public override string ToString()
        {
            return $"{AppUserId} {DestinationId}";
        }


    }
}
