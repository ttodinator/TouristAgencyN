using API.DTOs;
using API.Entities;
using API.Extensions;
using API.Helpers;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Authorize]
    public class DestinationController : BaseApiController
    {
        IUnitOfWork unitOfWork;
        IMapper mapper;
        IPhotoService photoService;

        public DestinationController(IUnitOfWork unitOfWork, IMapper mapper, IPhotoService photoService)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.photoService = photoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<DestinationDto>>> GetDestinations([FromQuery] DestinationParams destinationParams)
        {
            var userWLikes = await unitOfWork.UserRepository.GetUserWithLikesAsync(User.GetUserId());
            var destinations = await unitOfWork.DestinationRepository.GetDestinationsAsync(destinationParams);
            foreach (var item in destinations)
            {
                item.LikesCount = await unitOfWork.DestinationRepository.GetLikesAsync(item.Id);
            }
            Response.AddPaginationHeader(destinations.CurrentPage, destinations.PageSize, destinations.TotalCount, destinations.TotalPages);

            return Ok(destinations);
        }

        [HttpGet("{hotel}", Name = "GetDestination")]
        public async Task<ActionResult<DestinationDto>> GetDestination(string hotel)
        {
            return await unitOfWork.DestinationRepository.GetDestinationByNameAsync(hotel);
        }


        [HttpPut]
        public async Task<ActionResult> UpdateDestination(UpdateDestinationDto dto)
        {
            Destination destination = await unitOfWork.DestinationRepository.GetDestinationByIdAsync(dto.Id);

            destination.City = dto.City;
            destination.Hotel = dto.Hotel;
            destination.Type = dto.Type;
            destination.Transportation = dto.Transportation;
            destination.Stars = dto.Stars;
            destination.Price = dto.Price;
            destination.Description = dto.Description;

            destination.Rooms = new List<DestinationRooms>();


            foreach (int item in dto.Rooms)
            {
                DestinationRooms room = new DestinationRooms
                {
                    Destination = destination,
                    DestinationId = destination.Id,
                    RoomId = item
                };
                destination.Rooms.Add(room);
            }


            unitOfWork.DestinationRepository.Update(destination);
            if (await unitOfWork.Complete()) return NoContent();
            return BadRequest("Failed to update destination");
        }


        [Authorize(Policy = "RequireAdminOrModeratorRole")]
        [HttpPost]
        public async Task<ActionResult<AddDestinationDto>> aa(AddDestinationDto dto)
        {
            var user = await unitOfWork.UserRepository.GetUserByIdAsync(User.GetUserId());

            Destination destination = new Destination
            {
                Hotel = dto.Hotel,
                City = dto.City,
                Type = dto.Type,
                Transportation = dto.Transportation,
                Stars = dto.Stars,
                Price = dto.Price,
                Description = dto.Description
            };

            destination.Rooms = new List<DestinationRooms>();


            foreach (int item in dto.Rooms)
            {
                DestinationRooms room = new DestinationRooms
                {
                    Destination = destination,
                    RoomId = item
                };
                destination.Rooms.Add(room);
            }


            unitOfWork.DestinationRepository.Save(destination);

            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to make a reservation");
        }

        [Authorize(Policy = "RequireAdminOrModeratorRole")]
        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDto>> AddPhoto([FromQuery] int destinationId, IFormFile file)
        {
            //var user = await unitOfWork.UserRepository.GetUserByUsernameAsync(User.GetUsername());
            var destination = await unitOfWork.DestinationRepository.GetDestinationByIdAsync(destinationId);
            var result = await photoService.AddPhotoAsync(file);
            if (result.Error != null) return BadRequest(result.Error.Message);

            var photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };

            if (destination.Photos.Count == 0)
            {
                photo.IsMain = true;
            }

            destination.Photos.Add(photo);

            if (await unitOfWork.Complete())
            {
                //return CreatedAtRoute("GetUser", mapper.Map<PhotoDto>(photo));
                return CreatedAtRoute("GetDestination", new { hotel = destination.Hotel }, mapper.Map<PhotoDto>(photo));
                //return Ok();
            }


            return BadRequest("Problem adding photos");
        }

        [Authorize(Policy = "RequireAdminOrModeratorRole")]
        [HttpPut("set-main-photo")]
        public async Task<ActionResult> SetMainPhoto([FromQuery] EditPhotoDto dto)
        {

            var destination = await unitOfWork.DestinationRepository.GetDestinationByIdAsync(dto.destinationId);
            var photo = destination.Photos.FirstOrDefault(x => x.Id == dto.photoId);

            if (photo.IsMain) return BadRequest("This is already destinations main photo");

            var currentMain = destination.Photos.FirstOrDefault(x => x.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;

            if (await unitOfWork.Complete()) return NoContent();

            return BadRequest("Failed to set main photo");
        }

        [Authorize(Policy = "RequireAdminOrModeratorRole")]
        [HttpDelete("delete-photo")]
        public async Task<ActionResult> DeletePhoto([FromQuery] EditPhotoDto dto)
        {
            var destination = await unitOfWork.DestinationRepository.GetDestinationByIdAsync(dto.destinationId);

            var photo = destination.Photos.FirstOrDefault(x => x.Id == dto.photoId);

            if (photo == null) return NotFound();

            if (photo.IsMain) return BadRequest("You cannot delete main photo");

            if (photo.PublicId != null)
            {
                var result = await photoService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }

            destination.Photos.Remove(photo);
            if (await unitOfWork.Complete()) return Ok();

            return BadRequest("Failed to delte photo");
        }



    }
}
