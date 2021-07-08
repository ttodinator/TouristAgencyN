using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace API.Extensions
{
    /// <summary>
    /// Helper staticka koja klasa koja sluzi za dobijanje podataka o trenutnom korisniku
    /// </summary>
    public static class ClaimsPrincipleExtensions
    {
        /// <summary>
        /// Staticka metoda koja pronalazi Name za trenutno ulogovanog korisnika
        /// </summary>
        /// <param name="user">Trenutno ulogovani korisnik</param>
        /// <returns>Name korisnika</returns>
        public static string GetUsername(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.Name)?.Value;
        }
        /// <summary>
        /// Staticka metoda koja pronalazi Id za trenutno ulogovanog korisnika
        /// </summary>
        /// <param name="user">Trenutno ulogovani korisnik</param>
        /// <returns>Jedinstveni identifikator(Id) korisnika</returns

        public static int GetUserId(this ClaimsPrincipal user)
        {
            int a= int.Parse(user.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            return a;
        }
    }
}
