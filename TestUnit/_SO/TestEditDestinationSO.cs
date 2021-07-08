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
    class TestEditDestinationSO
    {
        TestContext context;
        Destination destination;


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
        public void TestEditDestination()
        {
            Destination destination1 = context.Destination.FirstOrDefault(x => x.City == "city");
            destination1.City = "city1";
            context.SaveChanges();
            Destination destination2 = context.Destination.FirstOrDefault(x => x.City == "city1");
            Assert.AreEqual(destination1, destination2);
        }
    }
}
