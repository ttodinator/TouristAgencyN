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
    class AppRoleTest
    {
        AppRole role;

        [SetUp]
        public void su()
        {
            role = new AppRole();
        }

        [TearDown]
        public void td()
        {
            role = null;
        }


        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(role);
        }

        [Test]
        public void TestConstructorWithField()
        {
            role = new AppRole("role");
            Assert.AreEqual("role", role.Name);
        }

        [Test]
        public void TestProperty()
        {
            role.Name = "role";
            Assert.AreEqual("role", role.Name);
        }

        [Test]
        public void TestList()
        {
            DateTime date = DateTime.Now;
            AppUser appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            AppRole rol1 = new AppRole("role1");
            List<AppUserRole> list = new List<AppUserRole>
            {
                new AppUserRole(appUser,rol1)
            };

            role.UserRoles = list;
            Assert.AreEqual(list, role.UserRoles);

        }

        [Test]
        public void TestToString()
        {
            role.Name="name";
            string s = role.ToString();
            Assert.IsTrue(s.Contains("name"));
        }

        [Test]
        public void TestEquals()
        {

            DateTime date = DateTime.Now;
            role = new AppRole("name");
            AppRole role1 = new AppRole("name");
            Assert.AreEqual(role, role1);

        }


    }
}
