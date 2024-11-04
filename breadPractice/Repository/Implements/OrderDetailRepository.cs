using breadPractice.DBConnection;
using breadPractice.Models;
using breadPractice.Repository.Interfaces;
using Dapper;
using System.Data;

namespace breadPractice.Repository.Implements
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        /// <summary>
        /// 連線字串
        /// </summary>
        private readonly IDbConnection _dbConnection;
        private readonly JanesBakeryConnection _janesBakeryConnection;
        public OrderDetailRepository(IDbConnection dbConnection, JanesBakeryConnection janesBakeryConnection)
        {
            _dbConnection = dbConnection;
            _janesBakeryConnection = janesBakeryConnection;
        }

        public async Task<int> CreateAsync(OrderDetail entity)
        {
            var sql = "INSERT INTO OrderDetail (OrderID,OrderDate, CustomerName, CustomerPhone, Address, IsInPersonDelivery, ShipDate, ExpectedPickupDate) " +
          "VALUES (@OrderID,@OrderDate, @CustomerName, @CustomerPhone, @Address, @IsInPersonDelivery, @ShipDate, @ExpectedPickupDate); " +
          "SELECT SCOPE_IDENTITY();";


            using (var conn = _janesBakeryConnection.dbConnection())
            {
                return await _dbConnection.QueryFirstOrDefaultAsync<int>(sql, entity);
            }
        }
        public Task<OrderDetail> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<OrderDetail>> GetListAsync(OrderDetail? entity)
        {
            var sql = "SELECT * FROM OrderDetail";

            if (!string.IsNullOrEmpty((entity.OrderID).ToString()))
            {
                using (var conn = _janesBakeryConnection.dbConnection())
                {
                    var result = await conn.QueryAsync<OrderDetail>(sql.ToString(), entity);
                    return result;
                }
            }
            else
            {
                return Enumerable.Empty<OrderDetail>();
            }
        }

        public Task<bool> UpdateAsync(OrderDetail entity)
        {
            throw new NotImplementedException();
        }
    }
}