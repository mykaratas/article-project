using System.Net.Cache;
namespace article.api.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using business.repositories;
    using System.Linq;
    using System;
    using article.data.models;
    using System.Collections.Generic;
    using article.api.Response;

    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public object GetCategories(int pageSize = 50, int pageNo = 1)
        {
            int total = _categoryRepository.GetTotalCount();

            var categories = _categoryRepository.ListAll(pageSize, pageNo);
            
            return Ok(new PagedResult<Category>(categories, pageNo, pageSize, total));

        }

        [HttpGet("{id}")]
        public object GetCategory(Guid id)
        {
            var category = _categoryRepository.GetById(id);
            if (category == null)
            {
                return StatusCode(404, new PagedResult<Category>(null,"kayıt bulunamadı",404));
            }
            return Ok(new PagedResult<Category>(category));

        }


        [HttpDelete("{id}")]
        public object DeleteCategory(Guid id)
        {
            try
            {
                _categoryRepository.Delete(id);
            }
            catch
            {
                return StatusCode(500, new PagedResult<Category>(id.ToString(), "kayıt bulunamadı", 404));
            }
            return Ok(new PagedResult<Category>(id.ToString()));
        }

        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category categoryDTO)
        {
            try
            {
                var category = _categoryRepository.Update(categoryDTO);
            }
            catch
            {
                return StatusCode(404, new PagedResult<Category>(categoryDTO.Id.ToString(), "kayıt bulunamadı", 404));

            }

            return Ok(new PagedResult<Category>(categoryDTO, "Veriler Başarılı bir şekilde güncellenmiştir.", 201));
        }


        [HttpPost]
        public IActionResult AddCategory([FromBody] Category categoryDTO)
        {
            var category = _categoryRepository.Add(categoryDTO);
            return Ok(new PagedResult<Category>(category));
        }
    }
}