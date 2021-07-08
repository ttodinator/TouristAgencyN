using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na destinacije
    /// </summary>
    public class Destination
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string Transportation { get; set; }
        private int stars;
        /// <summary>
        /// Propery Stars koje se odnosi na broj zvezdica koje odredjena destinacija poseduje
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// </summary>
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
        /// <summary>
        /// Lista svih rezervacija koje su ostvarene za  destinaciju
        /// </summary>
        public List<Reservation> Reservations { get; set; }
        /// <summary>
        /// Lista svih lajkova  destinacije
        /// </summary>
        public List<Like> Likes { get; set; }
        /// <summary>
        /// Lista svih soba koje ima destinaciju
        /// </summary>
        public List<DestinationRooms> Rooms { get; set; }
        /// <summary>
        /// Lista svih fotografija destinacije
        /// </summary>
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
