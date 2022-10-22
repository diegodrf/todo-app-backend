using Microsoft.Data.SqlClient;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repositories
{
    public class RoleRepository : GenericRepository<Role>
    {
        public RoleRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }
    }
}
