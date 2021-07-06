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
        private int stars;
        public int Stars
        {
            get { return stars; }
            set
            {
                if(value<1 || value > 7)
                {
                    throw new IndexOutOfRangeException("Number of stars must be between 1 and 7");
                }
                stars = value;
            }
        }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Type { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Like> Likes { get; set; }
        public List<DestinationRooms> Rooms { get; set; }

        public List<Photo> Photos { get; set; }


        public Destination()
        {

        }

        public Destination(int id, string city, string hotel, string transportation, int stars, string description, double price, DateTime dateAdded, string type)
        {
            Id = id;
            City = city;
            Hotel = hotel;
            Transportation = transportation;
            Stars = stars;
            Description = description;
            Price = price;
            DateAdded = dateAdded;
            Type = type;
        }

        public override string ToString()
        {
            return $"{Id} {City} {Hotel} {Transportation} {Stars} {Description} {Price} {DateAdded.ToString()} {Type}";
        }
    }
}
