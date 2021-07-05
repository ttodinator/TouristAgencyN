using API.DTOs;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class DestinationRepository : IDestinationRepository
    {
        private readonly DataContext context;
        private IMapper mapper;

        public DestinationRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<Destination> GetDestinationByIdAsync(int id)
        {
            var query = context.Destination
            .Include(r => r.Rooms)
            .Include(p => p.Photos)
            ;         //.SingleOrDefaultAsync(x => x.Hotel == hotel);



            return await query.FirstOrDefaultAsync(x => x.Id == id);
            //return await context.Destination.FindAsync(id);
        }

        public async Task<DestinationDto> GetDestinationByNameAsync(string hotel)
        {
            var query = context.Destination
                .Include(r => r.Rooms)
                .ProjectTo<DestinationDto>(mapper.ConfigurationProvider)
                .AsNoTracking();         //.SingleOrDefaultAsync(x => x.Hotel == hotel);



            return await query.FirstOrDefaultAsync(x => x.Hotel == hotel);
        }

        public Task<List<Destination>> GetDestinationsAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<PagedList<DestinationDto>> GetDestinationsAsync(DestinationParams destinationParams)
        {
            var query = context.Destination
                .Include(r => r.Rooms)
                .ProjectTo<DestinationDto>(mapper.ConfigurationProvider)
                .AsNoTracking();

            query = query.Where(d => d.Price >= destinationParams.minPrice && d.Price <= destinationParams.maxPrice);



            query = destinationParams.Type switch
            {
                "Europe" => query.Where(d => d.Type == "Europe"),
                "America" => query.Where(d => d.Type == "America"),
                "Asia" => query.Where(d => d.Type == "Asia"),
                "Middle East" => query.Where(d => d.Type == "Middle East"),
                _ => query
            };

            query = destinationParams.OrderBy switch
            {
                "priceLower" => query.OrderBy(d => d.Price),
                "priceHigher" => query.OrderByDescending(d => d.Price),
                "dateOlder" => query.OrderBy(d => d.DateAdded),
                "dateNewer" => query.OrderByDescending(d => d.DateAdded),
                _ => query.OrderByDescending(d => d.DateAdded)
            };

            return await PagedList<DestinationDto>.CreateAsync(
                query,
                destinationParams.PageNumber,
                destinationParams.PageSize
                );

        }

        public async Task<int> GetLikesAsync(int id)
        {
            return await context.Likes.Where(x => x.DestinationId == id).CountAsync();
        }

        public void Save(Destination destination)
        {
            context.Add(destination);
        }

        public void Update(Destination destination)
        {
            context.Entry(destination).State = EntityState.Modified;
        }
    }
}
