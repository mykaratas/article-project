using System.Net.Cache;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

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
        
        private IUnitOfWork _unitOfWork;

        public ArticlesController(IArticleRepository articleRepository,IUnitOfWork unitOfWork)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        public object GetArticles(int pageSize = 50, int pageNo = 1)
        {
            int total = _articleRepository.GetTotalCount();

            var articles = _unitOfWork.Articles.GetAllQ()
                .Include(b => b.ArticleCategories)
                    .ThenInclude(a => a.Category)
                        .ThenInclude(m => m.ArticleCategories)
                            .ThenInclude(c => c.Article)
                .ToList();
            return Ok(new PagedResult<Article>(articles, pageNo, pageSize, total));

        }

        [HttpGet("{id}")]
        public object GetArticle(Guid id)
        {
            var article = _unitOfWork.Articles.GetAllQ()
                .Include(b => b.ArticleCategories)
                    .ThenInclude(a => a.Category)
                        .ThenInclude(m => m.ArticleCategories)
                            .ThenInclude(c => c.Article).Where(m => m.Id == id)
                                .FirstOrDefault();
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
            catch
            {
                return StatusCode(500, new PagedResult<Article>(id, "kayıt bulunamadı", 404));
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
            catch
            {
                return StatusCode(404, new PagedResult<Article>(articleDTO.Id, "kayıt bulunamadı", 404));

            }

            return Ok(new PagedResult<Article>(articleDTO, "Veriler Başarılı bir şekilde güncellenmiştir.", 201));
        }


        [HttpPost]
        public IActionResult AddArticle([FromBody] Article articleDTO)
        {
                        
            foreach (var articleCategory in articleDTO.ArticleCategories)
            {
                var category = _unitOfWork.Categories.GetById(articleCategory.CategoryId);
                if (category == null)
                {
                    return StatusCode(404, "404 not found category");
                }
                articleCategory.Category = _unitOfWork.Categories.GetById(articleCategory.CategoryId);
                articleCategory.Article = articleDTO;
                articleCategory.ArticleId = articleDTO.Id;
            }
            
            var article = _unitOfWork.Articles.Add(articleDTO);
            
         
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