using breadPractice.Models;
using breadPractice.Parameter;
using System.Collections.Generic;

namespace breadPractice.Repository
{
    public interface ICategoriesRepository
    {
        /// <summary>
        /// 查詢類別列表
        /// </summary>
        /// <returns>類別列表</returns>
        Task<IEnumerable<Categories>> GetListAsync(Categories entity);

        /// <summary>
        /// 查詢類別
        /// </summary>
        /// <param name="id">類別ID</param>
        /// <returns>類別</returns>
        Task<Categories> GetAsync(int id);
        /// <summary>
        /// 新增類別
        /// </summary>
        /// <param name="entity">參數</param>
        /// <returns>新增類別的ID</returns>
        Task<int> CreateAsync(Categories entity);

        /// <summary>
        /// 修改類別
        /// </summary>
        /// <param name="id">類別ID</param>
        /// <param name="parameter">參數</param>
        /// <returns>是否成功</returns>
        Task<bool> UpdateAsync(Categories entity);

        Task<bool> DeleteAsync(int id);

    }
}
