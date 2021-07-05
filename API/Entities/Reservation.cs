using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPeople { get; set; }

        public double TotalPrice { get; set; }


    }
}
