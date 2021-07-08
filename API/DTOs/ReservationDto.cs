using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa za cuvanje rezervacije
    /// </summary>
    public class ReservationDto
    {
        public int DestinationId { get; set; }
        /// <summary>
        /// Lista datuma
        /// </summary>
        public List<DateTime> Dates { get; set; }
        public int NumberOfPeople { get; set; }
        public double TotalPrice { get; set; }
    }
}
