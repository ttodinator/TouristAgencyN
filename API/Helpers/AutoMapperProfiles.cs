using API.DTOs;
using API.Entities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    /// <summary>
    /// Klasa koja sluzi za podesavanje AutoMapper-a
    /// </summary>
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<RegisterDto, AppUser>();
            CreateMap<Destination, DestinationDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt
                   .MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<AppUser, UserDto>();
            CreateMap<UserEditDto, AppUser>();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Photo, PhotoDto>();


        }
    }
}
