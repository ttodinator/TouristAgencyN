using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Asocijativna klasa koja sluzi da poveze korisnike apliakcije i njihove uloge
    /// </summary>
    public class AppUserRole : IdentityUserRole<int>
    {
        /// <summary>
        /// Korinsik aplikacije
        /// </summary>
        public AppUser User { get; set; }
        /// <summary>
        /// Uloga korisnika aplikacije
        /// </summary>
        public AppRole Role { get; set; }
        /// <summary>
        /// Prazan kosntrutkor
        /// </summary>
        public AppUserRole()
        {

        }
        /// <summary>
        /// Konstruktor sa paramterima
        /// </summary>
        /// <param name="user">korisnik aplikacije</param>
        /// <param name="role">uloga korisnika aplikacije</param>
        public AppUserRole(AppUser user, AppRole role)
        {
            User = user;
            Role = role;
        }
        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string sa podacima o korisniku i njegovoj ulozi</returns>
        public override string ToString()
        {
            return $"{User.ToString()} {Role.ToString()}";
        }
    }
}
