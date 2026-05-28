using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Application.Dtos.CategoryDtos;

namespace ToDoApi.Application.Features.Categories.Queries.GetCategory
{
    public class GetCategoryHandler : IRequestHandler<GetCategoryQuery, CategoryDto>
    {
        private readonly IApplicationDbContext _context;

        public GetCategoryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CategoryDto> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories
                .Where(c => c.Id == request.Id && c.UserId == request.UserId)
                .Select(c => new CategoryDto(c.Id, c.Name, c.Color))
                .FirstOrDefaultAsync();

            if (category == null)
                throw new Exception("Task not found!");

            return category;
        }
    }
}
