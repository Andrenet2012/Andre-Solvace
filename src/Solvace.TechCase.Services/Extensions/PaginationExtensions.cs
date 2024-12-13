
using Microsoft.EntityFrameworkCore;
using Solvace.TechCase.Domain.Entities.ActionPlan.Dtos;

namespace Solvace.TechCase.Services.Extensions
{
    public static class PaginationExtensions
    {
        public static PaginationDto<T> AsPaginationDto<T>(this IEnumerable<T> items, int totalCount, int pageIndex, int pageSize) =>
            new PaginationDto<T>(items, totalCount, pageIndex, pageSize);

        public static async Task<(List<T> Items, int TotalCount)> PaginateAsync<T>(this IQueryable<T> query, int pageNumber, int pageSize)
        {
            var totalCount = await query.CountAsync();

            var items = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (items, totalCount);
        }
    }
}
