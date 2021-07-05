using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            /*CreateMap<RegisterDto, AppUser>();
            CreateMap<Destination, DestinationDto>()
                .ForMember(dest => dest.PhotoUrl, opt => opt
                   .MapFrom(src => src.Photos.FirstOrDefault(x => x.IsMain).Url));
            CreateMap<AppUser, UserDto>();
            CreateMap<UserEditDto, AppUser>();
            CreateMap<ReservationDto, Reservation>();
            CreateMap<Reservation, ReservationDto>();
            CreateMap<Photo, PhotoDto>();*/


        }
    }
}
