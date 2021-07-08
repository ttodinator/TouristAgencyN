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
    class TestEditAppUser
    {
        TestContext context;
        AppUser appUser;

        [SetUp]
        public void su()
        {
            context = new TestContext();
            appUser = new AppUser("name", "surname", DateTime.Now, "number", "email");
            context.AspNetUsers.Attach(appUser);
            context.AspNetUsers.Add(appUser);
            context.SaveChanges();
        }

        [TearDown]
        public void td()
        {
            context.Remove(appUser);
            context.SaveChanges();
            context.Dispose();

        }


        [Test]
        public void TestAddLike()
        {
            AppUser appUser1 = context.AspNetUsers.FirstOrDefault(x => x.Name == "name");
            appUser1.Name = "AAA";
            context.SaveChanges();
            AppUser appUser2 = context.AspNetUsers.FirstOrDefault(x => x.Name == "AAA");
            Assert.AreEqual(appUser1, appUser2);
        }
    }
}
