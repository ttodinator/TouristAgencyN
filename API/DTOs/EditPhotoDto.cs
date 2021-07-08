using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Dto klasa koja sluzi za izmenu fotografije
    /// </summary>
    public class EditPhotoDto
    {
        public int photoId { get; set; }
        public int destinationId { get; set; }

    }
}
