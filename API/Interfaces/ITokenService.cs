using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    /// <summary>
    /// Interfejs koji sluzi za generisanje JWT tokena
    /// </summary>
    public interface ITokenService
    {
        /// <summary>
        /// Metoda koja generise JWT token za korisnika.
        /// </summary>
        /// <param name="user">Objekat tipa AppUser koji se odnosi nakorsnika apliakcije</param>
        /// <returns>JWT token koji je tipa string</returns>
        Task<string> CreateToken(AppUser user);
    }
}
