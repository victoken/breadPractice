using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace breadPractice.DBConnection
{
    public class JanesBakeryConnection : IDbConnection
    {
        private readonly IConfiguration _config;
        private DbConnection _conn { get; set; }

        public JanesBakeryConnection(IConfiguration config)
        {
            _config = config;
            //創建 SQL連線物件，Odbc的話就把 SqlClientFactory 改寫成 OdbcFactory 即可
            _conn = SqlClientFactory.Instance.CreateConnection();
            //指派預設DB連線字串
            _conn.ConnectionString = config.GetConnectionString("JansBakery");
            // 設定CommandTimeout為 300秒 5分鐘
            Dapper.SqlMapper.Settings.CommandTimeout = 300;
        }

        public string ConnectionString
        {
            get
            {
                return this._conn.ConnectionString;
            }
            set
            {
                this._conn.ConnectionString = value;
            }
        }

        public int ConnectionTimeout
        {
            get { return this._conn.ConnectionTimeout; }
        }

        public string Database { get { return this._conn.Database; } }

        public ConnectionState State { get { return this._conn.State; } }

        public IDbTransaction BeginTransaction()
        {
            return this._conn.BeginTransaction();
        }

        public IDbTransaction BeginTransaction(IsolationLevel il)
        {
            return this._conn.BeginTransaction(il);
        }

        public void ChangeDatabase(string databaseName)
        {
            this._conn.ChangeDatabase(databaseName);
        }

        public void Open()
        {
            this._conn.Open();
        }

        public void Close()
        {
            this._conn.Close();
        }

        public IDbCommand CreateCommand()
        {
            return this._conn.CreateCommand();
        }

        public void Dispose()
        {
            this._conn.Dispose();
            this.Dispose();
        }
    }
}
