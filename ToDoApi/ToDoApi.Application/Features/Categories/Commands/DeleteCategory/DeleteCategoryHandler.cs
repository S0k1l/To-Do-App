using MediatR;
using ToDoApi.Application.Common.Interfaces;
using ToDoApi.Domain.Interfaces;

namespace ToDoApi.Application.Features.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCategoryHandler(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            if (await _repository.HasTaskItemsAsync(request.Id))
                throw new InvalidOperationException("Category contains tasks.");


            var category = await _repository.GetByIdAsync(request.Id);

            if (category == null || category.UserId != request.UserId)
                throw new Exception("Category not found!");

            _repository.Delete(category);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
