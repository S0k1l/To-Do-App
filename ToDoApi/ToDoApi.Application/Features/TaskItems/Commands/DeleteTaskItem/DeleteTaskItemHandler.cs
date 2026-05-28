using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Features.TaskItems.Commands.DeleteTaskItem
{
    public class DeleteTaskItemHandler : IRequestHandler<DeleteTaskItemCommand>
    {
        private readonly IRepository<TaskItem> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteTaskItemHandler(IRepository<TaskItem> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }
        public async Task Handle(DeleteTaskItemCommand request, CancellationToken cancellationToken)
        {
            var taskItem = await _repository.GetByIdAsync(request.Id);

            if (taskItem == null || taskItem.UserId != request.UserId)
                throw new Exception("Task not found!");

            _repository.Delete(taskItem);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
