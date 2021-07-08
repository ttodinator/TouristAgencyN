using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    /// <summary>
    /// Klasa koja sluzi za kreiranje paginirane liste destinacija
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public PagedList(List<T> items, int count, int PageNumber, int pageSize)
        {
            this.CurrentPage = PageNumber;
            this.TotalPages = (int)Math.Ceiling(count / (double)PageSize);
            this.PageSize = pageSize;
            this.TotalCount = count;
            AddRange(items);
        }

        /// <summary>
        /// Staticka metoda koja sluzi za kreiranje paginirane liste
        /// </summary>
        /// <param name="source">Upit iz baze</param>
        /// <param name="pageNumber">Broj strane</param>
        /// <param name="pageSize">Broj stavki na strani</param>
        /// <returns></returns>
        public static async Task<PagedList<T>> CreateAsync(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }

    }
}
