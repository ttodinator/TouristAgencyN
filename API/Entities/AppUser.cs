using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CellphoneNumber { get; set; }

        public string UserEmail { get; set; }

        public List<AppUserRole> UserRoles { get; set; }
        public List<Reservation> Reservations { get; set; }
        public List<Like> Likes { get; set; }
    }
}
