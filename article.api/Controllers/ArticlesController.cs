using System.Net.Cache;
namespace article.api.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using business.repositories;
    using System.Linq;
    using System;
    using article.data.models;
    using article.business.helpers.Searching;
    using System.Collections.Generic;
    using article.api.Response;
    using article.business.services;

    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly IArticleRepository _articleRepository;

        public ArticlesController(IArticleRepository articleRepository)
        {
            this._articleRepository = articleRepository;
        }

        [HttpGet]
        public object GetArticles(int pageSize = 50, int pageNo = 1)
        {
            int total = _articleRepository.GetTotalCount();

            var articles = _articleRepository.ListAll(pageSize, pageNo);
            
            return Ok(new PagedResult<Article>(articles, pageNo, pageSize, total));

        }

        [HttpGet("{id}")]
        public object GetArticle(Guid id)
        {
            var article = _articleRepository.GetById(id);
            if (article == null)
            {
                return StatusCode(404, new PagedResult<Article>(article,"kayıt bulunamadı",404));
            }
            return Ok(new PagedResult<Article>(article));

        }


        [HttpDelete("{id}")]
        public object DeleteArticle(Guid id)
        {
            try
            {
                _articleRepository.Delete(id);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
            return Ok(new PagedResult<Article>(id));
        }

        [HttpPut]
        public IActionResult UpdateArticle([FromBody] Article articleDTO)
        {

            try
            {
                var article = _articleRepository.Update(articleDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(404, new PagedResult<Article>(articleDTO.Id, "kayıt bulunamadı", 404));

            }

            return Ok(new PagedResult<Article>(articleDTO, "Veriler Başarılı bir şekilde güncellenmiştir.", 201));
        }


        [HttpPost]
        public IActionResult AddArticle([FromBody] Article articleDTO)
        {
            var article = _articleRepository.Add(articleDTO);
            return Ok(new PagedResult<Article>(article));
        }


        [HttpGet("search")]
        public object SearchArticle(string content, string title, string fullName, Guid? id, int pageSize = 50, int pageNo = 1)
        {
            ArticleSearchModel articleSearchModel = new ArticleSearchModel(id, content, title, fullName);
            var articles = _articleRepository.Search(articleSearchModel, pageSize, pageNo);

            return Ok(new PagedResult<Article>(articles, pageNo, pageSize, _articleRepository.GetSearchCount()));
        }
    }
}