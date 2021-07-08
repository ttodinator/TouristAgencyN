using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa za slanje korisnika aplikacije
    /// </summary>
    public class UserDto
    {
        public string Username { get; set; }
        public string Token { get; set; }
        /// <summary>
        /// Lista destinacija
        /// </summary>
        public List<Destination> Destination { get; set; }
        /// <summary>
        /// Lista rezervacija
        /// </summary>
        public List<Destination> Resevations { get; set; }
        /// <summary>
        /// Lista like-ova
        /// </summary>
        public List<int> Likes { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string CellphoneNumber { get; set; }

        public string UserEmail { get; set; }

    }
}
