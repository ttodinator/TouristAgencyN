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

        public AppRole()
        {

        }

        public AppRole(string roleName)
        {
            Name = roleName;
        }

        public override string ToString()
        {
            return $"{Name}";
        }

        public override bool Equals(object obj)
        {
            return obj is AppRole role &&
                   Name == role.Name;
        }
    }
}
