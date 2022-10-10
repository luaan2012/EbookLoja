using Dapper;
using Livros.Data.Data;
using Livros.Data.Interface;
using Livros.Domain.Models;
using Microsoft.Extensions.Configuration;

namespace Livros.Data.Repository
{
    public class CartRepository : BaseRepository, ICartRepository
    {
        public CartRepository(IConfiguration configuration) : base(configuration)
        {
        }

        ~CartRepository()
        {
            Dispose();
        }

        public async Task addCart(int id, int IdUser)
        {
            var connection = GetConnection();

            try
            {
                await connection.QueryAsync($"INSERT INTO Cart (IdEbook, IdUser) VALUES ('{id}', '{IdUser}')");
            }
            catch (System.Exception ex)
            {
                
                throw new Exception($"Error: {ex.Message}");
            }
            
        }

        public async Task RemoveCart(int idUser)
        {
             var connection = GetConnection();

            try
            {
                await connection.QueryFirstAsync($"DELETE FROM Cart where IdUser = '{idUser}'");
            }
            catch (System.Exception ex)
            {
                
                throw new Exception($"Error: {ex.Message}");
            }
        }

        public async Task<int> ListCart(int idUser)
        {
            var connection = GetConnection();

            try
            {
                return await connection.QueryFirstAsync<int>($"SELECT COUNT(*) FROM Cart WHERE IdUser = '{idUser}'");
            }
            catch (System.Exception ex)
            {
                throw new Exception($"Error: {ex.Message}");
            }
        }
    }
}