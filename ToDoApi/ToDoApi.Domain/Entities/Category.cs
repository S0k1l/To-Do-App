using ToDoApi.Domain.Common;

namespace ToDoApi.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; private set; } = null!;
        public string? Color { get; private set; }
        public Guid UserId { get; private set; }
        public User User { get; private set; } = null!;

        private readonly List<TaskItem> _taskItems = new();
        public IReadOnlyCollection<TaskItem> TaskItems => _taskItems;

        private Category()
        {
        }

        public Category(string name, string color, Guid userId)
        {
            Name = name;
            Color = color;
            UserId = userId;
        }

        public void Update(string name, string color)
        {
            Name = name;
            Color = color;
        }
    }
}
