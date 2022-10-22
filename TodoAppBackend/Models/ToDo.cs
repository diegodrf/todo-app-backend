namespace TodoAppBackend.Models
{
    public class ToDo: Entity
    {
        public string Title { get; set; } = default!;
        public string Content { get; set; } = default!;
        public int UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
    }
}
