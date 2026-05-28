using MediatR;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Application.Dtos;
using ToDoApi.Application.Dtos.TaskItemDtos;

namespace ToDoApi.Application.Features.TaskItems.Queries.GetTaskItems
{
    public class GetTaskItemsHandler : IRequestHandler<GetTaskItemsQuery, PaginationDto<TaskItemDto>>
    {
        private readonly IApplicationDbContext _context;

        public GetTaskItemsHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<PaginationDto<TaskItemDto>> Handle(GetTaskItemsQuery request, CancellationToken cancellationToken)
        {
            var query = _context.TaskItems.Where(t => t.UserId == request.UserId);


            if (request.Filter.CategoryId.HasValue)
            {
                query = query.Where(t => t.CategoryId == request.Filter.CategoryId.Value);

            }

            if (!string.IsNullOrWhiteSpace(request.Filter.Search))
            {
                var searchLower = request.Filter.Search.ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(searchLower)
                                      || (t.Description != null && t.Description.ToLower().Contains(searchLower)));
            }

            var totalCount = await query.CountAsync();

            query = query
                .Skip((request.Filter.PageNumber - 1) * request.Filter.PageSize)
                .Take(request.Filter.PageSize);


            var taskItems = await query
                 .Select(q => new TaskItemDto(q.Id, q.Title, q.Description, q.CategoryId, q.IsCompleted))
                 .ToListAsync();


            return new PaginationDto<TaskItemDto>
            {
                Items = taskItems,
                TotalCount = totalCount,
                PageNumber = request.Filter.PageNumber,
                PageSize = request.Filter.PageSize
            };
        }
    }
}
