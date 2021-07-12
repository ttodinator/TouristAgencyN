using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na korisnika apliakcije
    /// </summary>
    public class AppUser : IdentityUser<int>
    {
        /// <summary>
        /// Ime korisnika apliakcije
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Prezime korisnika aplikacije
        /// </summary>
        public string Surname { get; set; }
        /// <summary>
        /// Datum rodjenja korisnika aplikacije
        /// </summary>
        public DateTime DateOfBirth { get; set; }
        /// <summary>
        /// Broj telefona korisnika aplikacije
        /// </summary>

        public string CellphoneNumber { get; set; }
        /// <summary>
        /// Email korisnika aplikacije
        /// </summary>
        public string UserEmail { get; set; }
        /// <summary>
        /// Lista uloga koje korisnik apliakcije moze da poseduje
        /// </summary>
        public List<AppUserRole> UserRoles { get; set; }
        /// <summary>
        /// Lista koja se odnosi na sve rezervacije koje je korisnik izvrsio
        /// </summary>
        public List<Reservation> Reservations { get; set; }
        /// <summary>
        /// Lista koja se odnosi na sve like-ove korisnika
        /// </summary>
        public List<Like> Likes { get; set; }

        /// <summary>
        /// Prazan konstruktor
        /// </summary>
        public AppUser()
        {

        }

        /// <summary>
        /// Konstrutkor sa paramtrima
        /// </summary>
        /// <param name="name">ime korisnika</param>
        /// <param name="surname">prezime korisnika</param>
        /// <param name="dateOfBirth">datum rodjenja krisnika</param>
        /// <param name="cellphoneNumber">broj telefona korisnika</param>
        /// <param name="userEmail">email korisnika</param>
        public AppUser(string name, string surname, DateTime dateOfBirth, string cellphoneNumber, string userEmail)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CellphoneNumber = cellphoneNumber;
            UserEmail = userEmail;
        }
        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string koji sadrzi podatke o korisniku apliakcije</returns>
        public override string ToString()
        {
            return $" {Name} {Surname} {DateOfBirth.ToString()} {CellphoneNumber} {UserEmail}";
        }
        /// <summary>
        /// override equals metode
        /// </summary>
        /// <param name="obj">objekat s kojim se poredi</param>
        /// <returns>bool koji govori dda li su objekti jednaki</returns>
        public override bool Equals(object obj)
        {
            return obj is AppUser user &&
                   Id == user.Id &&
                   Name == user.Name &&
                   Surname == user.Surname &&
                   DateOfBirth == user.DateOfBirth &&
                   CellphoneNumber == user.CellphoneNumber &&
                   UserEmail == user.UserEmail;
        }
    }
}
