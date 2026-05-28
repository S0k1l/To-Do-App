using MediatR;
using ToDoApi.Domain.Entities;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Features.TaskItems.Commands.ToggleTaskComplete
{
    public class ToggleTaskCompleteHandler : IRequestHandler<ToggleTaskCompleteCommand>
    {
        private readonly IRepository<TaskItem> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ToggleTaskCompleteHandler(IRepository<TaskItem> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(ToggleTaskCompleteCommand request, CancellationToken cancellationToken)
        {
            var task = await _repository.GetByIdAsync(request.Id);
            if (task == null || task.UserId != request.UserId)
                throw new Exception("Task not found!");

            task.ToggleComplete();

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
