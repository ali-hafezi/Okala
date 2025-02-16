using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Okala.Domain.Entities;

namespace Okala.Query.Dapper;

public class DapperContext
{

    private readonly string _connectionString;

    public DapperContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<Crypto>> GetAllCryptoAsync()
    {
        using (var connection = new SqlConnection(_connectionString))
        {
            return await connection.QueryAsync<Crypto>("SELECT * FROM cryptos");
        }
    }

}
