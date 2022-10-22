namespace TodoAppBackend.Models
{
    public class User: Entity
    {
        private readonly ICollection<Role> _roles = new List<Role>();
        private readonly ICollection<ToDo> _toDos = new List<ToDo>();

        public string Username { get; set; } = default!;
        public string PasswordHash { get; set; } = default!;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool Blocked { get; set; }
        public string Name { get; set; } = default!;

        public IReadOnlyCollection<Role> Roles => _roles.ToArray();
        public IReadOnlyCollection<ToDo> Todos => _toDos.ToArray();

        public void AddRole(Role role)
        {
            _roles.Add(role);
        }

        public void AddToDo(ToDo todo)
        {
            _toDos.Add(todo);
        }
    }
}
