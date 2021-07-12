using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na uloge koje korisnik moze da poseduje
    /// </summary>
    public class AppRole : IdentityRole<int>
    {
        /// <summary>
        /// Lista svih korisnika koji poseduju odredjenu ulogu
        /// </summary>
        public List<AppUserRole> UserRoles { get; set; }

        /// <summary>
        /// Prazan konstrutkor
        /// </summary>
        public AppRole()
        {

        }

        /// <summary>
        /// Konstruktor sa parametrom
        /// </summary>
        /// <param name="roleName">string koji se odnosi na ime uloge</param>
        public AppRole(string roleName)
        {
            Name = roleName;
        }

        /// <summary>
        /// Override toString metode
        /// </summary>
        /// <returns>tring koji sandrzi podatke o AppRole</returns>
        public override string ToString()
        {
            return $"{Name}";
        }

        /// <summary>
        /// Overrride equals metode
        /// </summary>
        /// <param name="obj">Odnosi se na objekat sa kojim se objekat uporedjuje</param>
        /// <returns>bool koji govori da li su objekti koji su poredjeni jednaki</returns>
        public override bool Equals(object obj)
        {
            return obj is AppRole role &&
                   Name == role.Name;
        }
    }
}
