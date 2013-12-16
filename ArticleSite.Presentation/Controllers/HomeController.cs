using System.Linq;
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
            Article latestArticle = ArticleRepository.LatestArticle();

            if (latestArticle == null)
                return HttpNotFound();

            return View(latestArticle);
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ArticleDetails(int id = 0)
        {
            Article result = ArticleRepository.Find(id);

            if (result == null)
                return HttpNotFound();

            return View(result);
        }

        public ActionResult ArticleSummary(string searchTerm = "default")
        {
            List<Article> articlesByCategory = ArticleRepository.ArticlesByCategory(searchTerm);

            if (articlesByCategory.Count == 0)
                return HttpNotFound();

            return View(articlesByCategory);
        }

        public ActionResult Archive()
        {
            IEnumerable<IGrouping<int, Article>> result = ArticleRepository.ArticlesGroupedByYear();

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
