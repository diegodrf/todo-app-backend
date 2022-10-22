using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using TodoAppBackend.Models;

namespace TodoAppBackend.Repositories
{
    public class GenericRepository<T> where T : Entity
    {
        protected readonly SqlConnection _dbConnection;

        public GenericRepository(SqlConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<int> CreateAsync(T model)
        {
            return await _dbConnection.InsertAsync<T>(model);
        }

        public async Task DeleteByIdAsync(int id)
        {
            var model = await GetByIdAsync(id);
            await _dbConnection.DeleteAsync<T>(model);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbConnection.GetAllAsync<T>();
        }

        public Task<IEnumerable<T>> GetAllAsync(int skip, int take)
        {
            throw new NotImplementedException();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbConnection.GetAsync<T>(id);
        }

        public async Task UpdateAsync(T model)
        {
            await _dbConnection.UpdateAsync<T>(model);
        }
    }
}
