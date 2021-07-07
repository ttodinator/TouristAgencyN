using API.Entities;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TestUnit
{
    [TestFixture]
    class AppUserTest
    {
        AppUser appUser;

        [SetUp]
        public void su()
        {
            appUser = new AppUser();
        }

        [TearDown]
        public void td()
        {
            appUser = null;
        }


        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(appUser);
        }

        [Test]
        public void TestConstructorWithField()
        {
            DateTime date = DateTime.Now;
            appUser = new AppUser( "name", "surname", date, "060626", "appUser@gmail.com");
            Assert.AreEqual("name", appUser.Name);
            Assert.AreEqual("surname", appUser.Surname);
            Assert.AreEqual(date, appUser.DateOfBirth);
            Assert.AreEqual("060626", appUser.CellphoneNumber);
            Assert.AreEqual("appUser@gmail.com", appUser.UserEmail);
        }


        [Test]
        public void TestProperty()
        {
            appUser.Name = "name";
            Assert.AreEqual("name", appUser.Name);
        }

        [Test]
        public void TestList()
        {
            DateTime date = DateTime.Now;
            List<Reservation> reservations = new List<Reservation>
            {
                new Reservation(1,1,1,date,date,10,100),
                new Reservation(2,2,2,date,date,20,200),

            };

            appUser.Reservations = reservations;

            Assert.IsNotNull(reservations);
            Assert.IsNotNull(appUser);
            Assert.AreEqual(reservations, appUser.Reservations);

        }

        [Test]
        public void TestToString()
        {
            DateTime date = DateTime.Now;
            appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            string s = appUser.ToString();
            Assert.IsTrue(s.Contains("name"));
            Assert.IsTrue(s.Contains("surname"));
            Assert.IsTrue(s.Contains("060626"));
            Assert.IsTrue(s.Contains("appUser@gmail.com"));
            Assert.IsTrue(s.Contains(date.ToString()));
        }

        [Test]
        public void TestEquals()
        {

            DateTime date = DateTime.Now;
            appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            AppUser appUser1 = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            Assert.AreEqual(appUser, appUser1);

        }



    }
}
