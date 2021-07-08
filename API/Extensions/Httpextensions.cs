using API.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Extensions
{
    /// <summary>
    /// Staticka heleper klasa koja sluzi za rad sa http zahtevima
    /// </summary>
    public static class HttpExtensions
    {
        /// <summary>
        /// Staticka metoda koja postavlja paginacioni header u zaglvalje http zahteva
        /// </summary>
        /// <param name="response">odnosi se na http zahtev</param>
        /// <param name="currentPage">trenutna strana</param>
        /// <param name="itemsPerPage">broj stavki po strani</param>
        /// <param name="totalItems">ukupan broj stavki</param>
        /// <param name="totalPages">ukupan brojj stranica</param>
        public static void AddPaginationHeader(this HttpResponse response, int currentPage, int itemsPerPage, int totalItems, int totalPages)
        {
            var paginationHeader = new PaginationHeader(
                currentPage, itemsPerPage, totalItems, totalPages
                );
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            response.Headers.Add("Pagination", JsonSerializer.Serialize(paginationHeader, options));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }
    }
}
