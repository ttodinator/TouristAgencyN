using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext context;
        private IMapper mapper;

        public UserRepository(DataContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Like GetLike(int userId, int destinationId)
        {
            var likes = context.Likes.AsQueryable();
            Like l = likes.FirstOrDefault(l => l.AppUserId == userId && l.DestinationId == destinationId);
            return l;
        }

        public void DeleteLike(Like l)
        {
            context.Remove(l);
        }

        public async Task<List<DestinationDto>> GetAllLikedDestinations(int id)
        {
            var likes = context.Likes.AsQueryable();

            likes = likes.Where(l => l.AppUserId == id);

            likes = likes.Include(l => l.Destination);

            var destinations = likes.Select(like => new DestinationDto
            {
                Id = like.Destination.Id,
                City = like.Destination.City,
                Hotel = like.Destination.Hotel,
                Transportation = like.Destination.Transportation,
                Stars = like.Destination.Stars,
                Description = like.Destination.Description,
                Price = like.Destination.Price,
                DateAdded = like.Destination.DateAdded,
                Type = like.Destination.Type
            }).ToListAsync();

            return await destinations;

        }

        public async Task<AppUser> GetUserByIdAsync(int id)
        {

            return await context.Users.FindAsync(id);
        }

        public async Task<AppUser> GetUserByUsernameAsync(string username)
        {
            return await context.Users.SingleOrDefaultAsync(x => x.UserName == username);
        }

        public async Task<List<AppUser>> GetUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<AppUser> GetUserWithLikesAsync(int id)
        {
            return await context.Users.Where(u => u.Id == id).Include(u => u.Likes).FirstOrDefaultAsync();
        }

        public async Task<AppUser> GetUserWithReservationsAsync(int id)
        {
            return await context.Users.Where(u => u.Id == id).Include(u => u.Reservations).ThenInclude(u => u.Destination).FirstOrDefaultAsync();
        }





        public void Update(AppUser user)
        {
            context.Entry(user).State = EntityState.Modified;
        }
    }
}
