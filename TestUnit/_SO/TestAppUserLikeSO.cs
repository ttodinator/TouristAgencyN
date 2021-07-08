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
    class TestAppUserLikeSO
    {
        TestContext context;
        AppUser appUser;
        Destination destination;
        Like like;

        [SetUp]
        public void su()
        {
            context = new TestContext();
            appUser = new AppUser("name", "surname", DateTime.Now, "number", "email");
            destination = new Destination(0, "city", "hotel", "trans", 5, "desc", 10, DateTime.Now,"type");
            context.AspNetUsers.Attach(appUser);
            context.Destination.Attach(destination);
            context.AspNetUsers.Add(appUser);
            context.Destination.Add(destination);
            context.SaveChanges();
        }

        [TearDown]
        public void td()
        {
            context.Remove(like);
            context.Remove(appUser);
            context.Remove(destination);
            context.SaveChanges();
            context.Dispose();

        }


        [Test]
        public void TestAddLike()
        {
            AppUser appUser1 = context.AspNetUsers.FirstOrDefault(x => x.Name == "name");
            Destination destination1 = context.Destination.FirstOrDefault(x => x.City == "city");
            like = new Like(appUser1.Id, destination1.Id);
            appUser1.Likes = new List<Like>();
            appUser1.Likes.Add(like);
            context.SaveChanges();
            AppUser appUser2 = context.AspNetUsers.Include(x => x.Likes).FirstOrDefault(x => x.Id == appUser1.Id);
            Assert.AreEqual(appUser2, appUser);
        }

    }
}
