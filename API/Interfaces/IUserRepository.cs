using API.DTOs;
using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<List<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id);
        Task<AppUser> GetUserWithLikesAsync(int id);
        Task<AppUser> GetUserByUsernameAsync(string username);
        public Task<AppUser> GetUserWithReservationsAsync(int id);

        Like GetLike(int i, int j);

        void DeleteLike(Like l);
        Task<List<DestinationDto>> GetAllLikedDestinations(int id);
        ///Task<List<MemberDto>> GetMembersAsync(); umesto ovga vracacemo ovu listu ali cisto eto da ostane
        //Task<PagedList<MemberDto>> GetMembersAsync(UserParams userParams);
        //Task<MemberDto> GetMemberAsync(string username);
    }
}
