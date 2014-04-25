using System;
using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using ArticleSite.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ArticleSite.Services.Interfaces;
using Ninject;

namespace ArticleSite.Presentation.Controllers
{
    public class HomeController : ApplicationController
    {
        [Inject]
        public IEmailer MessagingService { get; set; }

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

            if (articlesByCategory == null)
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

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Contact(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    MessagingService.Contact = contact;
                    MessagingService.Message();

                    return RedirectToRoute("ContactConfirmed");
                }
                catch (Exception)
                {
                    return RedirectToRoute("ContactFailed");
                }
            }
            return View("ContactFailed");
        }

        public ActionResult ContactConfirmed()
        {
            return View("ContactConfirmed");
        }

        public ActionResult ContactFailed()
        {
            return View("ContactFailed");
        }
    }
}
