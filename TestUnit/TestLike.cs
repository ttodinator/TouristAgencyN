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
    class TestLike
    {
        Like like;

        [SetUp]
        public void su()
        {
            like = new Like();
        }

        [TearDown]
        public void td()
        {
            like = null;
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(like);
        }

        [Test]
        public void TestConstructorWithField()
        {

            like = DataInitializer.getLike();
            Assert.IsNotNull(like);
            Assert.AreEqual(1, like.AppUserId);
            Assert.AreEqual(3, like.DestinationId);
        }

        [Test]
        public void TestProperty()
        {
            like.AppUserId = 1;
            Assert.AreEqual(1, like.AppUserId);
        }


        [Test]
        public void TestToString()
        {
            like = DataInitializer.getLike();
            string s = like.ToString();
            Assert.IsTrue(s.Contains("1"));
            Assert.IsTrue(s.Contains("3"));
        }

        [Test]
        public void TestEquals()
        {
            like = DataInitializer.getLike();
            var serializer = JsonSerializer.Serialize(like);
            Like like1 = new Like(1, 3 );
            var serializer1 = JsonSerializer.Serialize(like1);
            Assert.AreEqual(serializer, serializer1);

        }




    }
}
