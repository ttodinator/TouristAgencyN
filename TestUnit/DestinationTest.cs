using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using NUnit.Framework;
using System.Text.Json;

namespace TestUnit
{
    [TestFixture]
    class DestinationTest
    {
        TestContext context = new TestContext();
        Destination destination;


        [SetUp]
        public void su()
        {
            destination = new Destination();
        }

        [TearDown]
        public void td()
        {
            destination = null;
        }


        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(destination);
        }

        [Test]
        public void TestConstructorWithField()
        {
            DateTime date = DateTime.Now;
            destination = new Destination(1, "city", "hotel", "transport", 5, "desc", 10, date, "type");
            Assert.IsNotNull(destination);
            Assert.AreEqual(1, destination.Id);
            Assert.AreEqual("city", destination.City);
            Assert.AreEqual("hotel", destination.Hotel);
            Assert.AreEqual("transport", destination.Transportation);
            Assert.AreEqual(5, destination.Stars);
            Assert.AreEqual("desc", destination.Description);
            Assert.AreEqual(10, destination.Price);
            Assert.AreEqual(date, destination.DateAdded);
            Assert.AreEqual("type", destination.Type);

        }

        [Test]
        public void TestProperty()
        {
            destination.Id = 1;
            Assert.AreEqual(1, destination.Id);
        }

        [Test]
        public void TestList()
        {
            List<Like> likes = new List<Like>
            {
                new Like(1,1),
                new Like(2,2)
            };

            destination.Likes = likes;

            Assert.IsNotNull(likes);
            Assert.IsNotNull(destination);
            Assert.AreEqual(likes, destination.Likes);
            
        }

        [Test]
        public void TestInsertStars()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => destination.Stars=8);
            Assert.That(ex.Message, Is.EqualTo("Number of stars must be between 1 and 7"));
        }

        [Test]
        public void TestToString()
        {
            DateTime date = DateTime.Now;
            destination = new Destination(1, "city", "hotel", "transport", 5, "desc", 10, date, "type");
            string s = destination.ToString();
            Assert.IsTrue(s.Contains("1"));
            Assert.IsTrue(s.Contains("city"));
            Assert.IsTrue(s.Contains("hotel"));
            Assert.IsTrue(s.Contains("transport"));
            Assert.IsTrue(s.Contains("desc"));
            Assert.IsTrue(s.Contains("10"));
            Assert.IsTrue(s.Contains(date.ToString()));
            Assert.IsTrue(s.Contains("type"));
        }

        [Test]
        public void TestEquals()
        {


            DateTime date = DateTime.Now;
            destination = new Destination(1, "city", "hotel", "transport", 5, "desc", 10, date, "type");
            var serializer = JsonSerializer.Serialize(destination);
            Destination destination1 = new Destination();
            destination1.Id = 1;
            destination1.City = "city";
            destination1.Hotel = "hotel";
            destination1.Transportation = "transport";
            destination1.Stars = 5;
            destination1.Description = "desc";
            destination1.Price = 10;
            destination1.DateAdded = date;
            destination1.Type = "type";
            var serializer1 = JsonSerializer.Serialize(destination1);
            Assert.AreEqual(serializer, serializer1);

        }

    }
}
