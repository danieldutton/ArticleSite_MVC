using ArticleSite.Model.Entities;
using ArticleSite.Repository.Interfaces;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    [Authorize]
    public class AdminController : ApplicationController
    {
        public AdminController(IArticleRepository articleRepository) 
            : base(articleRepository)
        {
        }

        public ActionResult Index()
        {
            var model = ArticleRepository.All;

            if (model == null)
                return HttpNotFound();

            return View(ArticleRepository.All);
        }

        public ActionResult Details(int id = 0)
        {
            Article article = ArticleRepository.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Article article)
        {
            if (ModelState.IsValid)
            {
                ArticleRepository.Add(article);

                return RedirectToAction("Index");
            }

            return View(article);
        }

        public ActionResult Edit(int id = 0)
        {
            Article article = ArticleRepository.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Article article)
        {
            if (ModelState.IsValid)
            {
                ArticleRepository.Update(article);
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Delete(int id = 0)
        {
            Article article = ArticleRepository.Find(id);
            if (article == null)
            {
                return HttpNotFound();
            }
            return View(article);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Article article = ArticleRepository.Find(id);

            if(article != null)
                ArticleRepository.Delete(article);

            return RedirectToAction("Index");
        }
    }
}