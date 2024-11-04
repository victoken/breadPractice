using breadPractice.DTO;
using breadPractice.Models;
using breadPractice.Parameter;

namespace breadPractice.Services.Interfaces
{
    public interface IOrderDetailService
    {
        Task<IEnumerable<OrderDetail>> GetListAsync(OrderDetailDTO? request);
        Task<ApiResponse> CreateAsync(OrderDetailDTO request);
        Task<Categories> GetByIdAsync(int id);
        Task<ApiResponse> UpdateAsync(int id, OrderDetailDTO dto);
        Task<ApiResponse> DeleteAsync(int id);
    }
}
