using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    /// <summary>
    /// Klasa koja se odnosi na fotografije
    /// </summary>
    [Table("Photos")]
    public class Photo
    {
        /// <summary>
        /// jedinstveni identifikator fotografije
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// url fotografije
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// bool koji oznacava da li je fotografija glavna
        /// </summary>
        public bool IsMain { get; set; }
        /// <summary>
        /// javni jedinstveni identifikator fotografije
        /// </summary>
        private string publicId;
        /// <summary>
        /// Property koji se odnosi na javni identifikator fotografije
        /// <exception cref="IndexOutOfRangeException"></exception>
        /// </summary>
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
        /// <summary>
        /// destinacija
        /// </summary>
        public Destination Destination { get; set; }
        /// <summary>
        /// jedinstveni identifikator destinacije
        /// </summary>
        public int DestinationId { get; set; }

        /// <summary>
        /// prazan konstruktor
        /// </summary>
        public Photo()
        {

        }

        /// <summary>
        /// konstruktor sa parametrima
        /// </summary>
        /// <param name="id">jedinstveni identifikator</param>
        /// <param name="url">url fotografije</param>
        /// <param name="isMain">bool koji govori da li je fotografija glavna</param>
        /// <param name="publicId">javni jedinstveni identifikator</param>
        /// <param name="destinationId">jedinstveni identifikator destinacije</param>
        public Photo(int id, string url, bool isMain, string publicId, int destinationId)
        {
            Id = id;
            Url = url;
            IsMain = isMain;
            PublicId = publicId;
            DestinationId = destinationId;
        }

        /// <summary>
        /// override toString metode
        /// </summary>
        /// <returns>string sa podacima o fotografiji</returns>
        public override string ToString()
        {
            return $"{Id} {Url} {IsMain} {PublicId} {DestinationId}";
        }
    }
}
