using ArticleSite.Model.Entities;
using ArticleSite.Presentation.ViewModels;
using ArticleSite.Repository.Interfaces;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public abstract class ApplicationController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public IArticleRepository ArticleRepository { get { return _articleRepository; } }


        protected ApplicationController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
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