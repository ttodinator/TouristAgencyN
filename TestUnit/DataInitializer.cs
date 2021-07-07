using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestUnit
{
    public static class DataInitializer
    {
        public static AppUser getAppUser()
        {
            DateTime date = DateTime.Now;
            AppUser appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            return appUser;
        }

        public static AppRole getAppRole()
        {
            AppRole role = new AppRole { Name = "role" };
            return role;
        }


    }
}
