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
        /// <summary>
        /// jedinstveni identifikator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// naziv grada
        /// </summary>
        public string City { get; set; }
        /// <summary>
        /// naziv hotela
        /// </summary>
        public string Hotel { get; set; }
        /// <summary>
        /// nacin vrste transporta
        /// </summary>
        public string Transportation { get; set; }
        /// <summary>
        /// broj zvezdica
        /// </summary>
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
        /// <summary>
        /// opis
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// cena po osobi
        /// </summary>
        public double Price { get; set; }
        /// <summary>
        /// datum dodavanja
        /// </summary>
        public DateTime DateAdded { get; set; } = DateTime.Now;
        /// <summary>
        /// tip destinacije
        /// </summary>
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

        /// <summary>
        /// prazan kosntruktor
        /// </summary>
        public Destination()
        {

        }

        /// <summary>
        /// konstru
        /// </summary>
        /// <param name="id">jedinstveni identifikator</param>
        /// <param name="city">naziv grada</param>
        /// <param name="hotel">naziv hotela</param>
        /// <param name="transportation">vrsta transporta</param>
        /// <param name="stars">broj zvezdica</param>
        /// <param name="description">opis</param>
        /// <param name="price">cena po osobi</param>
        /// <param name="dateAdded">datum dodavanja</param>
        /// <param name="type">tip</param>
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

        /// <summary>
        /// override to string metode
        /// </summary>
        /// <returns>string sa podacima o destinaciji</returns>
        public override string ToString()
        {
            return $"{Id} {City} {Hotel} {Transportation} {Stars} {Description} {Price} {DateAdded.ToString()} {Type}";
        }
    }
}
