using breadPractice.Models;
using breadPractice.Parameter;
using breadPractice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;


namespace breadPractice.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            _categoriesService = categoriesService;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<CategoriesParameter>))]
        public async Task<IActionResult> GetListAsync([FromQuery] CategoriesParameter? request)
        {
            var result = await _categoriesService.GetListAsync(request);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CategoriesParameter parameter)
        {
            var response = await _categoriesService.CreateAsync(parameter);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return CreatedAtAction(nameof(GetByIdAsync), new { CategoryID = response.Data });
            }
            else
            {
                return BadRequest(response);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int CategoryID)
        {
            var category = await _categoriesService.GetByIdAsync(CategoryID);
            if (category == null)
            {
                return NotFound(new ApiResponse(null, ResponseCode.BadRequest, "Category not found."));
            }
            return Ok(new ApiResponse(category, ResponseCode.OK, "Category retrieved successfully."));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] CategoriesParameter parameter)
        {
            var response = await _categoriesService.UpdateAsync(id, parameter);
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
            var response = await _categoriesService.DeleteAsync(id);
            if (response.ResponseCode == ResponseCode.OK)
            {
                return Ok(response);
            }
            else
            {
                return BadRequest(response);
            }
        }

        //[ApiController]
        //[Route("[controller]")]
        //public class CategoriesController : ControllerBase
        //{
        //    /// <summary>
        //    /// 種類資料操作
        //    /// </summary>
        //    private readonly CategoriesRepository _categoriesRepository;

        //    /// <summary>
        //    /// 建構式
        //    /// </summary>
        //    public CategoriesController()
        //    {
        //        this._categoriesRepository = new CategoriesRepository();
        //    }
        //    /// <summary>
        //    /// 查詢種類列表
        //    /// </summary>
        //    /// <returns></returns>
        //    [HttpGet]
        //    public List<Categories> GetList()
        //    {
        //        return (List<Categories>)this._categoriesRepository.GetList();
        //    }

        //    /// <summary>
        //    /// 查詢種類
        //    /// </summary>
        //    /// <param name="id">種類編號</param>
        //    /// <returns></returns>
        //    [HttpGet]
        //    [Route("{id}")]
        //    public Categories Get([FromRoute] int id)
        //    {
        //        var result = this._categoriesRepository.Get(id);
        //        if (result is null)
        //        {
        //            Response.StatusCode = 404;
        //            return null;
        //        }
        //        return result;
        //    }

        //    /// <summary>
        //    /// 新增種類
        //    /// </summary>
        //    /// <param name="parameter">種類參數</param>
        //    /// <returns></returns>
        //    [HttpPost]
        //    public IActionResult Insert([FromBody] CategoriesParameter parameter)
        //    {
        //        var result = this._categoriesRepository.Create(parameter);
        //        if (result > 0)
        //        {
        //            return Ok();
        //        }
        //        return StatusCode(500);
        //    }

        //    /// <summary>
        //    /// 更新種類
        //    /// </summary>
        //    /// <param name="id">種類編號</param>
        //    /// <param name="parameter">種類參數</param>
        //    /// <returns></returns>
        //    [HttpPut]
        //    [Route("{id}")]
        //    public IActionResult Update(
        //        [FromRoute] int id,
        //        [FromBody] CategoriesParameter parameter)
        //    {
        //        var targetCard = this._categoriesRepository.Get(id);
        //        if (targetCard is null)
        //        {
        //            return NotFound();
        //        }

        //        var isUpdateSuccess = this._categoriesRepository.Update(id, parameter);
        //        if (isUpdateSuccess)
        //        {
        //            return Ok();
        //        }
        //        return StatusCode(500);
        //    }

        //    /// <summary>
        //    /// 刪除種類
        //    /// </summary>
        //    /// <param name="id">種類編號</param>
        //    /// <returns></returns>
        //    [HttpDelete]
        //    [Route("{id}")]
        //    public IActionResult Delete([FromRoute] int id)
        //    {
        //        this._categoriesRepository.Delete(id);
        //        return Ok();
        //    }
    }
}

