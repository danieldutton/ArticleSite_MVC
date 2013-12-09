using ArticleSite.Model.Entities;
using ArticleSite.Presentation.ViewModels;
using ArticleSite.Repository.Interfaces;
using Ninject;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public IArticleRepository ArticleRepository { get { return _articleRepository; } }

        [Inject]
        public ICategoryRepository CategoryRepository { get; set; }


        protected ApplicationController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Article latestArticle = ArticleRepository.LatestArticle();
            latestArticle.Content = latestArticle.Content.Substring(0, 100);

            List<Category> categories = CategoryRepository.CategoriesByNameAscending(10);

            var masterLayout = new MasterPageViewModel {Article = latestArticle, Categories = categories}; 

            ViewBag.Layout = masterLayout;
            base.OnActionExecuted(filterContext);
        }
    }
}