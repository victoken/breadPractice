using AutoMapper;
using breadPractice.Models;
using breadPractice.Parameter;
using breadPractice.Repository;
using breadPractice.Repository.Implements;
using breadPractice.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace breadPractice.Services.Implements
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesService(ICategoriesRepository categoriesRepository, IMapper mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Categories>> GetListAsync(CategoriesParameter? request)
        {
            var entity = _mapper.Map<Categories>(request);
            var result = await _categoriesRepository.GetListAsync(entity);
            return result;
        }

        public async Task<ApiResponse> CreateAsync(CategoriesParameter parameter)
        {
            var entity = _mapper.Map<Categories>(parameter);
            var id = await _categoriesRepository.CreateAsync(entity);
            if (id > 0)
            {
                return new ApiResponse(id, ResponseCode.OK, "新增種類成功.");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "種類新增失敗");
            }
        }
        public async Task<Categories> GetByIdAsync(int id)
        {
            return await _categoriesRepository.GetAsync(id);
        }

        public async Task<ApiResponse> UpdateAsync(int id, CategoriesParameter parameter)
        {
            var entity = await _categoriesRepository.GetAsync(id);
            if (entity == null)
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "找不到要修改的資料");
            }

            _mapper.Map(parameter, entity);
            var isUpdated = await _categoriesRepository.UpdateAsync(entity);
            if (isUpdated)
            {
                return new ApiResponse(entity, ResponseCode.OK, "修改種類成功");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "修改種類失敗");
            }
        }

        public async Task<ApiResponse> DeleteAsync(int id) 
        {
            var entity = await _categoriesRepository.GetAsync(id);
            if (entity == null)
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "找不到要刪除的資料");
            }

            var isDeleted = await _categoriesRepository.DeleteAsync(id);
            if (isDeleted)
            {
                return new ApiResponse(null, ResponseCode.OK, "刪除種類成功");
            }
            else
            {
                return new ApiResponse(null, ResponseCode.BadRequest, "刪除種類失敗");
            }
        }
    }



    /// <summary>
    /// 查詢種類
    /// </summary>
    /// <param name="id">種類編號</param>
    /// <returns></returns>

    //public Categories Get(CategoriesParameter c)
    //{
    //    var result = this._categoriesRepository.Get(id);
    //    return result;
    //}

    /// <summary>
    /// 新增種類
    /// </summary>
    /// <param name="parameter">種類參數</param>
    /// <returns></returns>

    //public bool Insert(CategoriesParameter parameter)
    //    {
    //        try
    //        {
    //            var result = this._categoriesRepository.Create(parameter);
    //            return true;
    //        }
    //        catch (Exception)
    //        {
    //            return false;
    //        }

    //    }

    /// <summary>
    /// 更新種類
    /// </summary>
    /// <param name="id">種類編號</param>
    /// <param name="parameter">種類參數</param>
    /// <returns></returns>
    //[HttpPut]
    //[Route("{id}")]
    //    public IActionResult Update( CategoriesParameter parameter)
    //    {
    //        var targetCategory = this._categoriesRepository.Get(id);
    //        if (targetCategory is null)
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
    //}
}
