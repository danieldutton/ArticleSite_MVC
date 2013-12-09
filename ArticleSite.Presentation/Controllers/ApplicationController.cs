using ArticleSite.Model.Entities;
using ArticleSite.Presentation.ViewModels;
using ArticleSite.Repository.Interfaces;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        private readonly ICategoryRepository _categoryRepository;

        public IArticleRepository ArticleRepository { get { return _articleRepository; } }

        public ICategoryRepository CategoryRepository { get { return _categoryRepository; } }


        protected ApplicationController(IArticleRepository articleRepository, 
                                        ICategoryRepository categoryRepository)
        {
            _articleRepository = articleRepository;
            _categoryRepository = categoryRepository;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Article latestArticle = ArticleRepository.LatestArticle();
            latestArticle.Content = latestArticle.Content.Substring(0, 100);

            
            var masterLayout = new MasterPageViewModel {Article = latestArticle}; 

            ViewBag.Layout = masterLayout;
            base.OnActionExecuted(filterContext);
        }
    }
}