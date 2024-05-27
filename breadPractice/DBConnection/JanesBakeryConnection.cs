using Microsoft.Data.SqlClient;

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