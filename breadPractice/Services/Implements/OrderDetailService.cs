using AutoMapper;
using breadPractice.DTO;
using breadPractice.Models;
using breadPractice.Repository.Interfaces;
using breadPractice.Services.Interfaces;

namespace breadPractice.Services.Implements
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IMapper _mapper;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            _orderDetailRepository = orderDetailRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<OrderDetail>> GetListAsync(OrderDetailDTO? dto)
        {
            var entity = _mapper.Map<OrderDetail>(dto);
            var result = await _orderDetailRepository.GetListAsync(entity);
            return result;
        }
        public async Task<ApiResponse> CreateAsync(OrderDetailDTO dto)
        {
            var entity = _mapper.Map<OrderDetail>(dto);
            var id = await _orderDetailRepository.CreateAsync(entity);
            if (id > 0)
            {
                return new ApiResponse(id, ResponseCode.OK, "新增訂單成功.");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "訂單新增失敗");
            }
        }

        public Task<Categories> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
 
        public Task<ApiResponse> UpdateAsync(int id, OrderDetailDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task<ApiResponse> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}