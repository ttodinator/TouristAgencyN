using System;
using API.Entities;
using TestUnit;

namespace Proba
{
    class Program
    {
        static void Main(string[] args)
        {
            TestContext context = new TestContext();
            Room room = new Room();
            room.Name = "aaaa";
            context.Room.Add(room);
            context.SaveChanges();
            context.Dispose();
        }
    }
}
