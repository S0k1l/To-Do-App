using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Features.TaskItems.Commands.UpdateTaskItem
{
    public class UpdateTaskItemHandler : IRequestHandler<UpdateTaskItemCommand>
    {
        private readonly IRepository<TaskItem> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateTaskItemHandler(IRepository<TaskItem> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(UpdateTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _repository.GetByIdAsync(request.Id);

            if (taskItem == null || taskItem.UserId != request.UserId)
                throw new Exception("Task not found!");

            taskItem.Update(request.Title, request.Description, request.CategoryId);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
