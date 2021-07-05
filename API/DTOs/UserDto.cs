using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public List<Destination> Destination { get; set; }

        public List<Destination> Resevations { get; set; }

        public List<int> Likes { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CellphoneNumber { get; set; }

        public string UserEmail { get; set; }

    }
}
