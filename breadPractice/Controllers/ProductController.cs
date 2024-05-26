using breadPractice.DTO;
using breadPractice.Models;
using breadPractice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace breadPractice.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetListAsync([FromQuery] ProductDTO? request)
        {
            var result = await _productService.GetListAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] ProductDTO dto)
        {
            var response = await _productService.CreateAsync(dto);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { ProductID = response.Data });
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int ProductID)
        {
            var product = await _productService.GetByIdAsync(ProductID);
            if (product == null)
            {
                return NotFound(new ApiResponse(null, ResponseCode.BadRequest, "找不到商品."));
            }
            return Ok(new ApiResponse(product, ResponseCode.OK, "成功找到商品資料."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] ProductDTO dto)
        {
            var response = await _productService.UpdateAsync(id, dto);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _productService.DeleteAsync(id);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }
    }
}
