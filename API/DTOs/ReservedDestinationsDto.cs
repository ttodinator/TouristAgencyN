using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa koja sluzi za slanje svih rezervacija odredjenog korisnika
    /// </summary>
    public class ReservedDestinationsDto
    {
        public int DestinationId { get; set; }
        public string DestinationCity { get; set; }
        public string DestinationHotel { get; set; }
        public int NumberOfPeople { get; set; }
        public double TotalPrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
