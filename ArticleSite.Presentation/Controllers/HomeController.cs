using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly IArticleRepository _articleRepository;

        public HomeController(IArticleRepository articleRepository)
        {
            _articleRepository = articleRepository;
        }

        public ViewResult Index()
        {
            List<Article> articles = _articleRepository.All;

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
