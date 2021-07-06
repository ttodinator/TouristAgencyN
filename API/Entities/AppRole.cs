﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class AppRole : IdentityRole<int>
    {
        public List<AppUserRole> UserRoles { get; set; }

        public AppRole()
        {

        }

        public AppRole(List<AppUserRole> userRoles)
        {
            UserRoles = userRoles;
        }
    }
}
