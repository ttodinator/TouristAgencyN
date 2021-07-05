using API.DTOs;
using API.Entities;
using API.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IDestinationRepository
    {
        void Update(Destination destination);
        void Save(Destination destination);
        Task<List<Destination>> GetDestinationsAsync();
        Task<PagedList<DestinationDto>> GetDestinationsAsync(DestinationParams destinationParams);
        Task<Destination> GetDestinationByIdAsync(int id);
        Task<DestinationDto> GetDestinationByNameAsync(string hotel);

        Task<int> GetLikesAsync(int id);
    }
}
