using breadPractice.Models;

namespace breadPractice.Repository.Interfaces
{
    public interface IOrderDetailRepository
    {
        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns>訂單列表</returns>
        Task<IEnumerable<OrderDetail>> GetListAsync(OrderDetail entity);

        /// <summary>
        /// 查詢訂單
        /// </summary>
        /// <param name="id">訂單ID</param>
        /// <returns>產品</returns>
        Task<OrderDetail> GetAsync(int id);
        /// <summary>
        /// 新增訂單
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns>新增產品的ID</returns>
        Task<int> CreateAsync(OrderDetail entity);

        /// <summary>
        /// 修改訂單
        /// </summary>
        /// <param name="id">訂單ID</param>
        /// <param name="entity">參數</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(OrderDetail entity);

        /// <summary>
        /// 刪除訂單 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
    }
}