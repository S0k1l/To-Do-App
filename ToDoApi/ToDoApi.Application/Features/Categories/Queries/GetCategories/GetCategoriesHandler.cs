using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Application.Dtos.CategoryDtos;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategories
{
    public class GetCategoriesHandler : IRequestHandler<GetCategoriesQuery, List<CategoryDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoriesHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CategoryDto>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _context.Categories
                .Where(c => c.UserId == request.UserId)
                .Select(c => new CategoryDto(c.Id, c.Name, c.Color))
                .ToListAsync();
        }
    }
}
