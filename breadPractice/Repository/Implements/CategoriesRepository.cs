using breadPractice.Models;
using breadPractice.Parameter;
using breadPractice.Repository.Interfaces;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using static Dapper.SqlMapper;

namespace breadPractice.Repository.Implements
{
    public class CategoriesRepository : ICategoriesRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly string _connectString = "Server=.;TrustServerCertificate=True;Initial Catalog=JanesBakery;Integrated Security=True;";
        private readonly IDbConnection _dbConnection;
        public CategoriesRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }
        /// <summary>
        /// 查詢類別列表
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Categories>> GetListAsync(Categories entity)
        {
            var sql = new StringBuilder("SELECT * FROM Category WHERE 1=1");

            if (entity != null)
            {
                if (!string.IsNullOrEmpty(entity.CategoryName))
                {
                    sql.Append(" AND CategoryName = @CategoryName");
                }

                if (!string.IsNullOrEmpty(entity.Description))
                {
                    sql.Append(" AND Description = @Description");
                }
            }

            using (var conn = new SqlConnection(_connectString))
            {
                var result = await conn.QueryAsync<Categories>(sql.ToString(),entity);
                return result;
            }
            //var result = await _dbConnection.QueryAsync<Categories>(sql.ToString(), entity);
            //return result;
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Categories entity)
        {
            var sql = "UPDATE Category SET CategoryName = @CategoryName, Description = @Description WHERE CategoryID = @CategoryID";
            using (var conn = new SqlConnection(_connectString))
            {
                var rowsAffected = await conn.ExecuteAsync(sql, entity);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Category WHERE CategoryID = @Id";
            using (var conn = new SqlConnection(_connectString))
            {
                var rowsAffected = await conn.ExecuteAsync(sql, new { Id = id });
                return rowsAffected > 0;
            }
        }


        /// <summary>
        /// 查詢類別
        /// </summary>
        /// <returns></returns>
        public async Task<Categories> GetAsync(int id)
        {
            var sql =
            @"
            SELECT * 
            FROM Category 
            WHERE CategoryID = @id
            ";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = await conn.QueryFirstOrDefaultAsync<Categories>(sql, parameters);
                return result;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns></returns>
        public async Task<int> CreateAsync(Categories entity)
        {
            var sql =
            @"
            INSERT INTO Category 
            (
               [CategoryName],
               [Description]
            ) 
            VALUES 
            (
                 @CategoryName,
                 @Description
            );
            
            SELECT CAST(SCOPE_IDENTITY() as int);
            ";

            using (var conn = new SqlConnection(_connectString))
            {
                return await conn.QuerySingleAsync<int>(sql, entity);
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id">類別編號</param>
        /// <param name="parameter">參數</param>
        /// <returns></returns>
        public bool Update(int id, CategoriesParameter parameter)
        {
            var sql =
            @"
            UPDATE Category
            SET 
            [CategoryName] = @CategoryName
            ,[Description] = @Description
            WHERE 
            CategoryID = @CategoryID
            ";

            var parameters = new DynamicParameters(parameter);
            parameters.Add("CategoryID", id, DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
                return result > 0;
            }
        }

        /// <summary>
        /// 刪除類別
        /// </summary>
        /// <param name="id">類別編號</param>
        /// <returns></returns>
        public void Delete(int id)
        {
            var sql =
            @"
            DELETE FROM Category
            WHERE CategoryID = @CategoryID
            ";

            var parameters = new DynamicParameters();
            parameters.Add("CategoryID", id, DbType.Int32);

            using (var conn = new SqlConnection(_connectString))
            {
                var result = conn.Execute(sql, parameters);
            }
        }
    }
}


