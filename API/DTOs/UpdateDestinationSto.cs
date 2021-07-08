using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.DTOs
{
    /// <summary>
    /// Dto klasa za izmenu destinacije
    /// </summary>
    public class UpdateDestinationDto
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
        /// <summary>
        /// Lista soba koje poseduje destinacija
        /// </summary>
        public List<int> Rooms { get; set; }
    }
}
