using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class ReservationDto
    {
        public int DestinationId { get; set; }
        public List<DateTime> Dates { get; set; }
        public int NumberOfPeople { get; set; }
        public double TotalPrice { get; set; }
    }
}
