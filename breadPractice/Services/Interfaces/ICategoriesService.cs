using breadPractice.Models;
using breadPractice.Parameter;

namespace breadPractice.Services.Interfaces
{
    public interface ICategoriesService
    {
        Task<IEnumerable<Categories>> GetListAsync(CategoriesParameter? request);
        Task<ApiResponse> CreateAsync(CategoriesParameter request);
        Task<Categories> GetByIdAsync(int id);
        Task<ApiResponse> UpdateAsync(int id, CategoriesParameter parameter);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
