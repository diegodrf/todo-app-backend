using Microsoft.Data.SqlClient;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repositories
{
    public class ToDoRepository : GenericRepository<ToDo>
    {
        public ToDoRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
