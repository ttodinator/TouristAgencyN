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
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CellphoneNumber { get; set; }

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


        public AppUser()
        {

        }

        public AppUser(string name, string surname, DateTime dateOfBirth, string cellphoneNumber, string userEmail)
        {
            Name = name;
            Surname = surname;
            DateOfBirth = dateOfBirth;
            CellphoneNumber = cellphoneNumber;
            UserEmail = userEmail;
        }

        public override string ToString()
        {
            return $" {Name} {Surname} {DateOfBirth.ToString()} {CellphoneNumber} {UserEmail}";
        }

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
