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
        public int Id { get; set; }
        public AppUser User { get; set; }
        public int UserId { get; set; }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfPeople { get; set; }

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


        public Reservation()
        {

        }

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

        public override string ToString()
        {
            return $"{Id} {UserId} {DestinationId} {StartDate.ToString()} {EndDate.ToString()} {NumberOfPeople} {TotalPrice}";
        }
    }
}
