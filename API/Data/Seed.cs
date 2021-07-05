using API.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class Seed
    {
        public static async Task SeedUsers(UserManager<AppUser> userManager,
            RoleManager<AppRole> roleManager)
        {
            var roles = new List<AppRole>
            {
                new AppRole{Name="Member"},
                new AppRole{Name="Admin"},
                new AppRole{Name="Moderator"}
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }

            var admin = new AppUser
            {
                UserName = "admin"
            };

            await userManager.CreateAsync(admin, "Pa$$w0rd");
            await userManager.AddToRolesAsync(admin, new[] { "Admin", "Moderator" });
            await userManager.CreateAsync(petar, "P@$$w0rd");
            await userManager.AddToRoleAsync(petar, "Mmeber");





            var milos = new AppUser
            {
                Name = "Milos",
                Surname = "Todic",
                UserName = "milos",
                CellphoneNumber = "0649559864",
                UserEmail = "petar.tode.kv@gmail.com"
            };

            await userManager.CreateAsync(milos, "P@$$w0rd");
            await userManager.AddToRoleAsync(milos, "Mmeber");

        }
    }
}
