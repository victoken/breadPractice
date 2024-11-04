using AutoMapper;
using breadPractice.DTO;
using breadPractice.Models;
using breadPractice.Repository.Interfaces;
using breadPractice.Services.Interfaces;

namespace breadPractice.Services.Implements
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Product>> GetListAsync(ProductDTO? request)
        {
            var entity = _mapper.Map<Product>(request);
            var result = await _productRepository.GetListAsync(entity);
            return result;
        }
        public async Task<Product> GetByIdAsync(int id)
        {
            return await _productRepository.GetAsync(id);
        }

        public async Task<ApiResponse> CreateAsync(ProductDTO dto)
        {
            var entity = _mapper.Map<Product>(dto);
            var id = await _productRepository.CreateAsync(entity);
            if (id > 0)
            {
                return new ApiResponse(id, ResponseCode.OK, "新增產品成功.");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "產品新增失敗");
            }
        }

        public async Task<ApiResponse> UpdateAsync(int id, ProductDTO dto)
        {
            var entity = await _productRepository.GetAsync(id);

            if (entity == null)
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "找不到要修改的資料");
            }
            _mapper.Map(dto, entity);

            var isUpdated = await _productRepository.UpdateAsync(entity);
            if (isUpdated)
            {
                return new ApiResponse(entity, ResponseCode.OK, "修改產品資料成功");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "修改產品資料失敗");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id)
        {
            var entity = await _productRepository.GetAsync(id);
            if (entity == null)
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "找不到要刪除的資料");
            }

            var isDeleted = await _productRepository.DeleteAsync(id);
            if (isDeleted)
            {
                return new ApiResponse(null, ResponseCode.OK, "刪除產品資料成功");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "刪除產品資料失敗");
            }
        }
    }
}