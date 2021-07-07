using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Text.Json;
using API.Entities;

namespace TestUnit
{
    [TestFixture]
    class ReservationTest
    {
        Reservation reservation;

        [SetUp]
        public void su()
        {
            reservation = new Reservation();
        }

        [TearDown]
        public void td()
        {
            reservation = null;
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(reservation);
        }

        [Test]
        public void TestConstructorWithField()
        {

            reservation = DataInitializer.getReservation();
            Assert.IsNotNull(reservation);
            Assert.AreEqual(1, reservation.Id);
            Assert.AreEqual(2, reservation.UserId);
            Assert.AreEqual(3, reservation.DestinationId);
            Assert.AreEqual(
                DataInitializer.getReservation().StartDate, reservation.StartDate);
            Assert.AreEqual(
                DataInitializer.getReservation().EndDate, reservation.EndDate);
            Assert.AreEqual(10, reservation.NumberOfPeople);
            Assert.AreEqual(200, reservation.TotalPrice);
        }

        [Test]
        public void TestProperty()
        {
            reservation.Id = 1;
            Assert.AreEqual(1, reservation.Id);
        }



        [Test]
        public void TestInsertTotalPrice()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => reservation.TotalPrice = 12000);
            Assert.That(ex.Message, Is.EqualTo("Total price must be between a and 10000"));
        }

        [Test]
        public void TestToString()
        {
            reservation = DataInitializer.getReservation();
            string s = reservation.ToString();
            Assert.IsTrue(s.Contains("1"));
            Assert.IsTrue(s.Contains("2"));
            Assert.IsTrue(s.Contains("3"));
            Assert.IsTrue(s.Contains(DataInitializer.getReservation().StartDate.ToString()));
            Assert.IsTrue(s.Contains(DataInitializer.getReservation().EndDate.ToString()));
            Assert.IsTrue(s.Contains("10"));
            Assert.IsTrue(s.Contains("200"));
        }

        [Test]
        public void TestEquals()
        {
            reservation = DataInitializer.getReservation();
            var serializer = JsonSerializer.Serialize(reservation);
            Reservation reservation1 = new Reservation(1, 2, 3, DataInitializer.getReservation().StartDate, DataInitializer.getReservation().EndDate, 10, 200);
            var serializer1 = JsonSerializer.Serialize(reservation1);
            Assert.AreEqual(serializer, serializer1);

        }






    }
}
