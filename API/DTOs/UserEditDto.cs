using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa za izmenu korisnika apliakcije
    /// </summary>
    public class UserEditDto
    {
        public string Username { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }

        public string CellphoneNumber { get; set; }

        public string UserEmail { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
