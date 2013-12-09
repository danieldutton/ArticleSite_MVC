using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public class HomeController : ApplicationController
    {
        public HomeController(IArticleRepository articleRepository) 
            : base(articleRepository)
        {
        }

        public ActionResult Index()
        {
            List<Article> articles = ArticleRepository.All;

            if (articles == null)
                return HttpNotFound();

            return View(articles);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ArticleDetails(int id)
        {
            Article result = ArticleRepository.Find(id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        public ActionResult Archive()
        {
            var result = ArticleRepository.ArticlesGroupedByYear();

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}
