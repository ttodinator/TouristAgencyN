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
    class TestPhoto
    {
        Photo photo;

        [SetUp]
        public void su()
        {
            photo = new Photo();
        }

        [TearDown]
        public void td()
        {
            photo = null;
        }

        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(photo);
        }

        [Test]
        public void TestConstructorWithField()
        {

            photo = DataInitializer.getPhoto();
            Assert.IsNotNull(photo);
            Assert.AreEqual(1, photo.Id);
            Assert.AreEqual("url", photo.Url);
            Assert.AreEqual(true,photo.IsMain);
            Assert.AreEqual("publicId", photo.PublicId);
            Assert.AreEqual(3, photo.DestinationId);
        }

        [Test]
        public void TestProperty()
        {
            photo.Id = 1;
            Assert.AreEqual(1, photo.Id);
        }



        [Test]
        public void TestInsertPublicId()
        {
            var ex = Assert.Throws<IndexOutOfRangeException>(() => photo.PublicId = "");
            Assert.That(ex.Message, Is.EqualTo("PublicId cant be null or empty string"));
        }

        [Test]
        public void TestToString()
        {
            photo = DataInitializer.getPhoto();
            string s = photo.ToString();
            Assert.IsTrue(s.Contains("1"));
            Assert.IsTrue(s.Contains("url"));
            Assert.IsTrue(s.Contains(true.ToString()));
            Assert.IsTrue(s.Contains("publicId"));
            Assert.IsTrue(s.Contains("3"));
        }

        [Test]
        public void TestEquals()
        {
            photo = DataInitializer.getPhoto();
            var serializer = JsonSerializer.Serialize(photo);
            Photo photo1 = new Photo(1, "url", true, "publicId", 3);
            var serializer1 = JsonSerializer.Serialize(photo1);
            Assert.AreEqual(serializer, serializer1);

        }
    }
}
