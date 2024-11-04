using breadPractice.DBConnection;
using breadPractice.Models;
using breadPractice.Repository.Interfaces;
using Dapper;
using System.Data;
using static Dapper.SqlMapper;

namespace breadPractice.Repository.Implements
{
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        //private readonly string _connectString = "Server=.;TrustServerCertificate=True;Initial Catalog=JanesBakery;Integrated Security=True;";
        private readonly IDbConnection _dbConnection;
        private readonly JanesBakeryConnection _janesBakeryConnection;
        public ProductRepository(IDbConnection dbConnection, JanesBakeryConnection janesBakeryConnection)
        {
            _dbConnection = dbConnection;
            _janesBakeryConnection = janesBakeryConnection;
        }

        /// <summary>
        /// 查詢產品列表(改成正確連線方式版)
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Product>> GetListAsync(Product? entity)
        {
            var sql = "SELECT * FROM Product";

            if (!string.IsNullOrEmpty((entity.ProductID).ToString()))
            {
                using (var conn = _janesBakeryConnection.dbConnection())
                {
                    var result = await conn.QueryAsync<Product>(sql.ToString(), entity);
                    return result;
                }
            }
            else
            {
                return Enumerable.Empty<Product>();
            }
        }

        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns></returns>
        //public async Task<IEnumerable<Product>> GetListAsync(Product entity)
        //{
        //    var sql = "SELECT * FROM Product";
        //    var parameters = new DynamicParameters();

        //    if (!string.IsNullOrEmpty((entity.ProductID).ToString()))
        //    {
        //        sql += " WHERE ProductID = @ProductID";
        //        parameters.Add("@ProductID", entity.ProductID);
        //    }

        //    var result = await _dbConnection.QueryAsync<Product>(sql.ToString(), entity);
        //    return result;
        //}

        /// <summary>
        /// 修改產品
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns></returns>
        public async Task<bool> UpdateAsync(Product entity)
        {
            var sql = "UPDATE Product SET ProductName = @ProductName, CategoryID = @CategoryID, ProductUnit = @ProductUnit, ProductDescription = @ProductDescription, " +
                      "OriginalPrice = @OriginalPrice, Price = @Price, StartDate = @StartDate, EndDate = @EndDate, IsAvailable = @IsAvailable " +
                      "WHERE ProductID = @ProductID";

            using (var conn = _janesBakeryConnection.dbConnection())
            {
                var rowsAffected = await _dbConnection.ExecuteAsync(sql, entity);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var sql = "DELETE FROM Product WHERE ProductID = @ProductID";
            var dto = new DynamicParameters();
            dto.Add("ProductID", id, DbType.Int32);
            using (var conn = _janesBakeryConnection.dbConnection())
            {
                var rowsAffected = await _dbConnection.ExecuteAsync(sql, dto);
                return rowsAffected > 0;
            }
        }

        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <returns></returns>
        public async Task<Product> GetAsync(int id)
        {
            var sql = "SELECT * FROM Product WHERE ProductID = @ProductID";

            var parameters = new DynamicParameters();
            parameters.Add("Id", id, DbType.Int32);
            using (var conn = _janesBakeryConnection.dbConnection())
            {
                var result = await _dbConnection.QueryFirstOrDefaultAsync<Product>(sql, new { ProductID = id });
                return result;
            }
        }

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns></returns>
        public async Task<int> CreateAsync(Product entity)
        {
            var sql = "INSERT INTO Product (ProductName, CategoryID, ProductUnit, ProductDescription, OriginalPrice, Price, StartDate, EndDate, IsAvailable) " +
                      "VALUES (@ProductName, @CategoryID, @ProductUnit, @ProductDescription, @OriginalPrice, @Price, @StartDate, @EndDate, @IsAvailable); " +
                      "SELECT SCOPE_IDENTITY();";

            using (var conn = _janesBakeryConnection.dbConnection())
            {
                return await _dbConnection.QueryFirstOrDefaultAsync<int>(sql, entity);
            }
        }
    }
}