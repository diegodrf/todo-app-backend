using Dapper.Contrib.Extensions;

namespace TodoAppBackend.Models
{
    public class Entity
    {
        [Key]
        public int Id { get; set; }
    }
}
