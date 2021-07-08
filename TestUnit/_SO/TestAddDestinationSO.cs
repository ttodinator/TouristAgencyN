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
    class TestAddDestinationSO
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
        public void TestAddDestination()
        {
            Destination destination1 = context.Destination.FirstOrDefault(d => d.City == "city");
            Assert.AreEqual(destination1, destination);
        }


    }
}
