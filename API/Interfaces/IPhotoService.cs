using CloudinaryDotNet.Actions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Interfaces
{
    /// <summary>
    /// Servis koji sluzi za rad sa fotografijama na platoformi Cloudinary
    /// </summary>
    public interface IPhotoService
    {
        /// <summary>
        /// Asinhrona Metoda koja dodaje novu fotografiju
        /// </summary>
        /// <param name="file">Fotografija koja treba da se doda</param>
        /// <returns>Task</returns>
        Task<ImageUploadResult> AddPhotoAsync(IFormFile file);
        /// <summary>
        /// Asinhrona metofa koja brise fotografiju
        /// </summary>
        /// <param name="publicId">Jedinstveni identifikator fotografije</param>
        /// <returns>Task</returns>
        Task<DeletionResult> DeletePhotoAsync(string publicId);
    }
}
