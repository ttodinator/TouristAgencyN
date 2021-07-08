using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using API.Entities;

namespace TestUnit._SO
{
    [TestFixture]
    class TestAppUserReservation
    {
        TestContext context;
        AppUser appUser;
        Destination destination;
        Reservation reservation;


        [SetUp]
        public void su()
        {
            context = new TestContext();
            appUser = new AppUser("name", "surname", DateTime.Now, "number", "email");
            destination = new Destination(0, "city", "hotel", "trans", 5, "desc", 10, DateTime.Now, "type");
            context.AspNetUsers.Attach(appUser);
            context.Destination.Attach(destination);
            context.AspNetUsers.Add(appUser);
            context.Destination.Add(destination);
            context.SaveChanges();
        }

        [TearDown]
        public void td()
        {
            context.Remove(reservation);
            context.Remove(appUser);
            context.Remove(destination);
            context.SaveChanges();
            context.Dispose();

        }

        [Test]
        public void TestAddReservation()
        {
            AppUser appUser1 = context.AspNetUsers.FirstOrDefault(x => x.Name == "name");
            Destination destination1 = context.Destination.FirstOrDefault(x => x.City == "city");
            reservation = new Reservation(0, appUser1.Id, destination1.Id, DateTime.Now, DateTime.Now, 20, 100);
            appUser1.Reservations = new List<Reservation>();
            appUser1.Reservations.Add(reservation);
            context.SaveChanges();
            AppUser appUser2 = context.AspNetUsers.Include(x => x.Reservations).FirstOrDefault(x => x.Id == appUser1.Id);
            Assert.AreEqual(appUser2, appUser);
        }

    }
}
