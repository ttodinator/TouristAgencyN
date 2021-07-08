using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using API.Entities;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;

namespace TestUnit._SO
{
    [TestFixture]
    class TestAddDestinationPhotoSO
    {
        TestContext context;
        Destination destination;
        Photo photo;

        [SetUp]
        public void su()
        {
            context = new TestContext();
            destination = new Destination(0, "city", "hotel", "trans", 5, "desc", 10, DateTime.Now, "type");
            context.Destination.Attach(destination);
            context.Destination.Add(destination);
            context.SaveChanges();
        }

        [TearDown]
        public void td()
        {
            context.Remove(destination);
            context.SaveChanges();
            context.Dispose();

        }

        [Test]
        public void TestAddPhotoDestination()
        {
            Destination destination1 = context.Destination.FirstOrDefault(x => x.City == "city");
            photo = new Photo(0,"url",true,"publicId",destination1.Id);
            destination1.Photos = new List<Photo>();
            destination1.Photos.Add(photo);
            context.SaveChanges();
            Destination destination2 = context.Destination.Include(x => x.Photos).FirstOrDefault(x => x.City == "city");
            Assert.AreEqual(destination2, destination1);
            
        }

    }
}
