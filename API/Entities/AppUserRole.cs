using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppUserRole : IdentityUserRole<int>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }

        public AppUserRole()
        {

        }

        public AppUserRole(AppUser user, AppRole role)
        {
            User = user;
            Role = role;
        }

        public override string ToString()
        {
            return $"{User.ToString()} {Role.ToString()}";
        }
    }
}
