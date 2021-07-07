using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace TestUnit
{
    using API.Entities;
    using NUnit.Framework;
    class AppUserRoleTest
    {
        AppUserRole appUserRole;


        [SetUp]
        public void su()
        {
            appUserRole = new AppUserRole();
        }

        [TearDown]
        public void td()
        {
            appUserRole = null;
        }


        [Test]
        public void TestIsNotNull()
        {
            Assert.IsNotNull(appUserRole);
        }

        [Test]
        public void TestConstructorWithField()
        {
            DateTime date = DateTime.Now;
            AppUser appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            AppRole role = new AppRole("role");
            appUserRole = new AppUserRole(appUser, role);
            Assert.AreEqual(appUser, appUserRole.User);
            Assert.AreEqual(role, appUserRole.Role);

        }

        [Test]
        public void TestProperty()
        {
            DateTime date = DateTime.Now;
            AppUser appUser = new AppUser("name", "surname", date, "060626", "appUser@gmail.com");
            appUserRole.User = appUser;
            Assert.AreEqual(appUser, appUserRole.User);

        }

        [Test]
        public void TestToString()
        {
            AppUser appUser = DataInitializer.getAppUser();
            AppRole role = DataInitializer.getAppRole();
            appUserRole.User = appUser;
            appUserRole.Role = role;

            string s = appUserRole.ToString();
            Assert.IsTrue(s.Contains("name"));
            Assert.IsTrue(s.Contains("surname"));
            Assert.IsTrue(s.Contains("060626"));
            Assert.IsTrue(s.Contains("appUser@gmail.com"));
            Assert.IsTrue(s.Contains(DataInitializer.getAppUser().DateOfBirth.ToString()));
            Assert.IsTrue(s.Contains(DataInitializer.getAppRole().Name));
        }

        [Test]
        public void TestEquals()
        {
            AppUser appUser = DataInitializer.getAppUser();
            AppRole role = DataInitializer.getAppRole();
            appUserRole.User = appUser;
            appUserRole.Role = role;

            var serializer = JsonSerializer.Serialize(appUserRole);

            AppUserRole appUserRole1 = new AppUserRole(appUser, role);
            var serialize1 = JsonSerializer.Serialize(appUserRole1);

            Assert.AreEqual(serializer, serialize1);


        }


    }
}
