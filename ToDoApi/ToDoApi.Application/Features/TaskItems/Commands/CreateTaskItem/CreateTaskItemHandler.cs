using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Features.TaskItems.Commands.CreateTaskItem
{
    public class CreateTaskItemHandler : IRequestHandler<CreateTaskItemCommand, Guid>
    {
        private readonly IRepository<TaskItem> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateTaskItemHandler(IRepository<TaskItem> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = new TaskItem(request.Title, request.Description, request.UserId, request.CategoryId);

            await _repository.AddAsync(taskItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return taskItem.Id;
        }
    }
}
