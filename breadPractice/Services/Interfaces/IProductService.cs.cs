using breadPractice.DTO;
using breadPractice.Models;

namespace breadPractice.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<Product>> GetListAsync(ProductDTO? request);
        Task<Product> GetByIdAsync(int id);
        Task<ApiResponse> CreateAsync(ProductDTO request);
        Task<ApiResponse> UpdateAsync(int id, ProductDTO parameter);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
