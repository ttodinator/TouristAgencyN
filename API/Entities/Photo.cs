using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    [Table("Photos")]
    public class Photo
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
        private string publicId;
        public string PublicId 
        {
            get { return publicId; }
            set
            {
                if(value==null || string.IsNullOrEmpty(value))
                {
                    throw new IndexOutOfRangeException("PublicId cant be null or empty string");
                }
                publicId = value;
            }
        }
        public Destination Destination { get; set; }
        public int DestinationId { get; set; }


        public Photo()
        {

        }

        public Photo(int id, string url, bool isMain, string publicId, int destinationId)
        {
            Id = id;
            Url = url;
            IsMain = isMain;
            PublicId = publicId;
            DestinationId = destinationId;
        }


        public override string ToString()
        {
            return $"{Id} {Url} {IsMain} {PublicId} {DestinationId}";
        }
    }
}
