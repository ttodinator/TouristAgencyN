using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na rezervacije
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// jedinstveni identifikator
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// korisnik apliakcije
        /// </summary>
        public AppUser User { get; set; }
        /// <summary>
        /// jedinstveni identifikator korisnika aplikacije
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// destinacija
        /// </summary>
        public Destination Destination { get; set; }
        /// <summary>
        /// jedinstveni identifikator destinacije
        /// </summary>
        public int DestinationId { get; set; }
        /// <summary>
        /// datum pocetka rezervacije
        /// </summary>
        public DateTime StartDate { get; set; }
        /// <summary>
        /// datum kraja reyervacije
        /// </summary>
        public DateTime EndDate { get; set; }
        /// <summary>
        /// broj ljudi na koje se odnosi rezervacija
        /// </summary>
        public int NumberOfPeople { get; set; }
        /// <summary>
        /// ukupna cena
        /// </summary>
        private double totalPrice;
        /// <summary>
        /// Property koji se odnosi na ukupnu cenu
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// </summary>
        public double TotalPrice 
        {
            get { return totalPrice; }
            set
            {
                if(value<1 || value>10000)
                {
                    throw new IndexOutOfRangeException("Total price must be between a and 10000");
                }
                totalPrice=value;
            }
        }

        /// <summary>
        /// prazan konstruktor
        /// </summary>
        public Reservation()
        {

        }
        /// <summary>
        /// konstruktor sa parametrima
        /// </summary>
        /// <param name="id">jedinstveni identifikator</param>
        /// <param name="userId">jedinstveni identifikator korisnika</param>
        /// <param name="destinationId">jedinstveni identifikator destinacije</param>
        /// <param name="startDate">datum pocetka rezervacije</param>
        /// <param name="endDate">datum kraja rezervacije</param>
        /// <param name="numberOfPeople">broj ljudi</param>
        /// <param name="totalPrice">ukupna cena</param>
        public Reservation(int id, int userId, int destinationId, DateTime startDate, DateTime endDate, int numberOfPeople, double totalPrice)
        {
            Id = id;
            UserId = userId;
            DestinationId = destinationId;
            StartDate = startDate;
            EndDate = endDate;
            NumberOfPeople = numberOfPeople;
            TotalPrice = totalPrice;
        }

        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string sa podacima o rezervaciji</returns>
        public override string ToString()
        {
            return $"{Id} {UserId} {DestinationId} {StartDate.ToString()} {EndDate.ToString()} {NumberOfPeople} {TotalPrice}";
        }
    }
}
