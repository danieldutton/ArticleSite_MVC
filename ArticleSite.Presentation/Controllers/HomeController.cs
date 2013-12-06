using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public class HomeController : ApplicationController
    {
        public HomeController(IArticleRepository articleRepository) : base(articleRepository)
        {
        }

        public ActionResult Index()
        {
            List<Article> articles = ArticleRepository.All;

            if (articles == null)
                return HttpNotFound();

            return View(articles);
        }

        public ViewResult About()
        {
            return View();
        }

        public ViewResult Contact()
        {
            return View();
        }
    }
}
