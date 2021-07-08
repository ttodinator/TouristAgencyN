using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    /// <summary>
    /// Interfejs koji sluzi za implementaciju UnitOfWork pattern-a
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Metoda koja se poziva radi provere da li je operacija izvrsena uspesno
        /// </summary>
        /// <returns>Boolean vrednosti koja govori o statusu izvrsenja operacija</returns>
        Task<bool> Complete();
        /// <summary>
        /// Property koji govori da li je doslo do neke promene u UnitOfWork-u
        /// </summary>
        /// <returns>Boolean vrednosti koja govori o statusu promene </returns>
        bool HasChanged();
        /// <summary>
        /// Property koji se odnosi na repozitorijum za korisnike aplikacije
        /// </summary>
        public IUserRepository UserRepository { get; }
        /// <summary>
        /// Property koji se odnosi na repozitorijum za destinacije
        /// </summary>
        public IDestinationRepository DestinationRepository { get; }
    }
}
