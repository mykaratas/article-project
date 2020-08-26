using System.Net.Cache;
namespace article.api.Controllers
{

    using Microsoft.AspNetCore.Mvc;
    using business.repositories;
    using System.Linq;
    using System;
    using article.data.models;
    using article.business.helpers.Searching;

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
        public object GetArticles(int limit = 15, int offset = 0)
        {
            return _articleRepository.ListAll(limit, offset).Select(x => new
            {
                x.Id,
                x.FullName
            });
        }

        [HttpGet("{id}")]
        public object GetArticle(Guid id)
        {
            return _articleRepository.GetById(id);
        }


        [HttpDelete("{id}")]
        public object DeleteArticle(Guid id)
        {
            _articleRepository.Delete(id);
            return Accepted();
        }

        [HttpPut]
        public IActionResult UpdateArticle([FromBody] Article articleDTO)
        {
            _articleRepository.Update(articleDTO);
            return Ok();
        }

        [HttpPost]
        public IActionResult AddArticle([FromBody] Article articleDTO)
        {
            _articleRepository.Add(articleDTO);
            return Ok();
        }


        [HttpGet("{id}")]
        public object GetTitle(Guid id)
        {
            return _articleRepository.GetById(id);
        }


        [HttpGet("search")]
        public object SearchArticle(string content, string title, string fullName, Guid? id)
        {
            ArticleSearchModel articleSearchModel = new ArticleSearchModel(id, content, title, fullName);
            return _articleRepository.Search(articleSearchModel);
        }
    }
}