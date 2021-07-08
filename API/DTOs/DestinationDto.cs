using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa koja sluzi za slanje destinacije 
    /// </summary>
    public class DestinationDto
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Hotel { get; set; }
        public string Transportation { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime DateAdded { get; set; } = DateTime.Now;
        public string Type { get; set; }
        bool isLikedByCurrentUser { get; set; } = false;
        /// <summary>
        /// Lista svih soba koja poseduje destinacija
        /// </summary>
        public List<DestinationRooms> Rooms { get; set; }
        /// <summary>
        /// Lista svih fotografija koje poseduje destinacija
        /// </summary>
        public List<Photo> Photos { get; set; }
        public string PhotoUrl { get; set; }
        public int LikesCount { get; set; } = 0;
    }
}
