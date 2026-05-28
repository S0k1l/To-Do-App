using ToDoApi.Domain.Common;

namespace ToDoApi.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Email { get; private set; } = null!;
        public string PasswordHash { get; private set; } = null!;

        private readonly List<TaskItem> _taskItems = new();
        public IReadOnlyCollection<TaskItem> TaskItems => _taskItems;

        private User()
        {
        }

        public User(string email, string passwordHash)
        {
            Email = email;
            PasswordHash = passwordHash;
        }
    }
}
