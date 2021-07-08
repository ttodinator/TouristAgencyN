using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using API.Entities;
using NUnit.Framework;


namespace TestUnit
{
    [TestFixture]
    class RoomTest
    {
        Room  room;

        [SetUp]
        public void su()
        {
            room = new Room();
        }

        [TearDown]
        public void td()
        {
            room = null;
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(room);
        }

        [Test]
        public void TestConstructorWithField()
        {

            room = DataInitializer.getRoom();
            Assert.IsNotNull(room);
            Assert.AreEqual(1, room.Id);
            Assert.AreEqual("room", room.Name);
        }

        [Test]
        public void TestProperty()
        {
            room.Id = 1;
            Assert.AreEqual(1, room.Id);
        }



        [Test]
        public void TestToString()
        {
            room = DataInitializer.getRoom();
            string s = room.ToString();
            Assert.IsTrue(s.Contains("1"));
            Assert.IsTrue(s.Contains("room"));
        }

        [Test]
        public void TestEquals()
        {
            room = DataInitializer.getRoom();
            var serializer = JsonSerializer.Serialize(room);
            Room room1 = new Room(1, "room");
            var serializer1 = JsonSerializer.Serialize(room1);
            Assert.AreEqual(serializer, serializer1);

        }



    }
}
