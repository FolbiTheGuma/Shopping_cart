using Nakupni_Kosik.Components.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Nakupni_Kosik.Services
{
    public class ShoppingListService
    {
        private readonly string _connectionString;

        public ShoppingListService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task AddItemAsync(ShoppingItem item)
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "INSERT INTO ShoppingItems (Name, Quantity) VALUES (@Name, @Quantity)";
            await connection.ExecuteAsync(sql, item);
        }

        public async Task<IEnumerable<ShoppingItem>> GetItemsAsync()
        {
            using var connection = new SqlConnection(_connectionString);
            string sql = "SELECT * FROM ShoppingItems";
            return await connection.QueryAsync<ShoppingItem>(sql);
        }
    }
}
