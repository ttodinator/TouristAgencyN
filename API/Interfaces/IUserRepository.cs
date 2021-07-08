using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    /// <summary>
    /// Repozitorijum za korisnike aplikacije
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Metoda za izmenu korisnika apliakcije
        /// </summary>
        /// <param name="user">Korisnik aplikacije</param>
        void Update(AppUser user);
        /// <summary>
        /// Metoda koja kao povratnu vrednost ima listu svih korisnika aplikacije
        /// </summary>
        /// <returns>Lista korisnika aplikacije</returns>
        Task<List<AppUser>> GetUsersAsync();
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima korisnika sa zadatim id-em
        /// </summary>
        /// <param name="id">Jedinstveni identifikator korisnika</param>
        /// <returns>Korisnik aplikacije</returns>
        Task<AppUser> GetUserByIdAsync(int id);
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima korisnika sa zadatim id-em, sadrzi i listu like-ova
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Korisnik apliakcije</returns>
        Task<AppUser> GetUserWithLikesAsync(int id);
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima korisnika sa zadatim username-om
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Korisnik apliakcije</returns>
        Task<AppUser> GetUserByUsernameAsync(string username);
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima korisnika sa zadatim id-em, sadrzi i listu reservacija
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Korisnik apliakcije</returns>
        public Task<AppUser> GetUserWithReservationsAsync(int id);
        /// <summary>
        /// Metoda koja pronalazi like na osnovu zadatih parametara
        /// </summary>
        /// <param name="i">Odnosi se na jedinistveni identifikator korisnika apliakcije</param>
        /// <param name="j">Odnosi se na jedinistveni identifikator destinacije</param>
        /// <returns></returns>
        Like GetLike(int i, int j);
        /// <summary>
        /// Metoda koja brise zadati Like
        /// </summary>
        /// <param name="l">Objekat tipa Like koji treba da se obrise</param>
        void DeleteLike(Like l);
        /// <summary>
        /// Metoda koja kao povratnu vrednost ima listu svih destinacija koje je korisnik like-ovao
        /// </summary>
        /// <param name="id">Odnosi se na jedinstveni identifikator korisnika aplikacije</param>
        /// <returns>Lista destinacija koje je korisnik like-ovao</returns>
        Task<List<DestinationDto>> GetAllLikedDestinations(int id);
    }
}
