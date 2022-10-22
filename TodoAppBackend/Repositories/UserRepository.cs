using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using System.Linq;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repositories
{
    public class UserRepository : GenericRepository<User>
    {
        public UserRepository(SqlConnection dbConnection) : base(dbConnection)
        {
        }

        public override async Task<IEnumerable<User>> GetAllAsync()
        {
            var query = @"
                SELECT
	                U.*,
	                R.*,
                    T.*
                FROM [USERS] AS U
                INNER JOIN [USERSROLES] AS UR ON UR.USERID = U.ID
                INNER JOIN [ROLES] AS R ON R.ID = UR.ROLEID
                LEFT JOIN [TODOS] AS T ON T.USERID = U.ID";

            var users = new List<User>();

            User map(User user, Role role, ToDo? toDo)
            {
                var thisUser = users.FirstOrDefault(_ => _.Id == user.Id);
                if (thisUser is null)
                {
                    thisUser = user;
                    users.Add(thisUser);
                } 
                
                if(thisUser.Roles.FirstOrDefault(_ => _.Id == role.Id) is null)
                {
                    thisUser.AddRole(role);
                }
                

                if(toDo is not null)
                {
                    thisUser.AddToDo(toDo);
                }

                return thisUser;
            }
            await _dbConnection.QueryAsync<User, Role, ToDo, User>(query, map, splitOn: "Id");
            return users;
        }
    }
}
