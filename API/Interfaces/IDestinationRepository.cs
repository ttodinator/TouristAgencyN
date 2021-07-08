using API.DTOs;
using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    /// <summary>
    /// Repozitorijum za destinacije
    /// </summary>
    public interface IDestinationRepository
    {
        /// <summary>
        /// Metoda za izmenu destiancije 
        /// </summary>
        /// <param name="destination">Destinacija</param>
        void Update(Destination destination);
        /// <summary>
        /// Metoda koja pamti destinaciju
        /// </summary>
        /// <param name="destination">Destinacija</param>
        void Save(Destination destination);
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima listu svih destinacija
        /// </summary>
        /// <returns>Lista svih destiancija</returns>
        Task<List<Destination>> GetDestinationsAsync();
        /// <summary>
        /// Asinhrona metoda koja kao povratnu vrednost ima listu svih destinacija
        /// </summary>
        /// <param name="destinationParams">Parametri destinacije </param>
        /// <returns>Paginirana lista svih destiancija</returns>
        Task<PagedList<DestinationDto>> GetDestinationsAsync(DestinationParams destinationParams);
        /// <summary>
        /// Metoda koja pronalazi destinaciju na osnovu zadatog parametra
        /// </summary>
        /// <param name="id">Jedinstveni identifiaktor destinacije</param>
        /// <returns>Task</returns>
        Task<Destination> GetDestinationByIdAsync(int id);
        /// <summary>
        /// Metoda koja pronalazi destinaciju na osnovu zadatog parametra
        /// </summary>
        /// <param name="hotel"></param>
        /// <returns></returns>
        Task<DestinationDto> GetDestinationByNameAsync(string hotel);

        Task<int> GetLikesAsync(int id);
    }
}
