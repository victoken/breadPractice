using breadPractice.DTO;
using breadPractice.Models;
using breadPractice.Parameter;
using breadPractice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace breadPractice.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailervice;

        public OrderDetailController(IOrderDetailService orderDetailervice)
        {
            _orderDetailervice = orderDetailervice;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoriesParameter>))]
        public async Task<IActionResult> GetListAsync([FromQuery] OrderDetailDTO? dto)
        {
            var result = await _orderDetailervice.GetListAsync(dto);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] OrderDetailDTO dto)
        {
            var response = await _orderDetailervice.CreateAsync(dto);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { OrderDetaiID = response.Data });
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int Orderid)
        {
            var orderDetail = await _orderDetailervice.GetByIdAsync(Orderid);
            if (orderDetail == null)
            {
                return NotFound(new ApiResponse(null, ResponseCode.BadRequest, "OrderDetail not found."));
            }
            return Ok(new ApiResponse(orderDetail, ResponseCode.OK, "orders retrieved successfully."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] OrderDetailDTO dto)
        {
            var response = await _orderDetailervice.UpdateAsync(id, dto);
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
            var response = await _orderDetailervice.DeleteAsync(id);
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