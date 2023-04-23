using Microsoft.Data.SqlClient;
using System.Data;

namespace testIDBcon.infrastructure
{
    public class DapperContext
    {
        private readonly IConfiguration _configuration;
        public readonly string? _connection;

        public DapperContext(IConfiguration configuration)
        {
            _configuration= configuration;
            _connection = configuration.GetConnectionString("SqlConnection");
        }
        public IDbConnection Create() { return new SqlConnection(_connection); }
    }
}
