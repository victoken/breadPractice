using breadPractice.Models;

namespace breadPractice.Repository.Interfaces
{
    public interface IProductRepository
    {
        /// <summary>
        /// 查詢產品列表
        /// </summary>
        /// <returns>產品列表</returns>
        Task<IEnumerable<Product>> GetListAsync(Product entity);

        /// <summary>
        /// 查詢產品
        /// </summary>
        /// <param name="id">產品ID</param>
        /// <returns>產品</returns>
        Task<Product> GetAsync(int id);
        /// <summary>
        /// 新增產品
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns>新增產品的ID</returns>
        Task<int> CreateAsync(Product entity);

        /// <summary>
        /// 修改產品
        /// </summary>
        /// <param name="id">產品ID</param>
        /// <param name="entity">參數</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(Product entity);

        /// <summary>
        /// 刪除產品 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteAsync(int id);
    }
}

