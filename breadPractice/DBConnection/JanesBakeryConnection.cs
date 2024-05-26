using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.Common;

namespace breadPractice.DBConnection
{
    public class JanesBakeryConnection
    {
        private readonly IConfiguration _config;

        public JanesBakeryConnection(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection dbConnection()
        {
            return new SqlConnection(_config.GetConnectionString("JansBakery"));
        }
    }
}