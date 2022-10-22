using Microsoft.Data.SqlClient;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
