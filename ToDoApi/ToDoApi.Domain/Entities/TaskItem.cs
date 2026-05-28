using ToDoApi.Domain.Common;

namespace ToDoApi.Domain.Entities
{
    public class TaskItem : BaseEntity
    {
        public string Title { get; private set; } = null!;
        public string? Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;
        public Guid? CategoryId { get; private set; }
        public Category? Category { get; private set; }

        private TaskItem() { }
        public TaskItem(string title, string? description, Guid userId, Guid? categoryId)
        {
            Title = title;
            Description = description;
            IsCompleted = false;
            UserId = userId;
            CategoryId = categoryId;
        }

        public void Update(string title, string? description, Guid? categoryId)
        {
            Title = title;
            Description = description;
            CategoryId = categoryId;
        }

        public void ToggleComplete()
        {
            IsCompleted = !IsCompleted;
        }
    }
}
