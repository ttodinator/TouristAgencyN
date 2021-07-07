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

        public static Reservation getReservation()
        {
            DateTime date = new DateTime(1999, 3, 3);
            Reservation reservation = new Reservation(1, 2, 3, date, date, 10, 200);
            return reservation;
        }

        public static Room getRoom()
        {
            Room room = new Room(1, "room");
            return room;
        }

        public static Like getLike()
        {
            Like like = new Like(1, 3);
            return like;
        }

        public static Photo getPhoto()
        {
            Photo photo = new Photo(1, "url", true, "publicId", 3);
            return photo;
        }


    }
}
