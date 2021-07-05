using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class Destination
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string Transportation { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Type { get; set; }
        //public List<Reservation> Reservations { get; set; }
        //public List<Like> Likes { get; set; }
        public List<DestinationRooms> Rooms { get; set; }

        //public List<Photo> Photos { get; set; }
    }
}
