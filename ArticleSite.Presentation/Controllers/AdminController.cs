using ArticleSite.DataAccess;
using ArticleSite.Model.Entities;
using System.Linq;
using System.Web.Mvc;

namespace ArticleSite.Presentation.Controllers
{
    [Authorize]
    public class AdminController : ApplicationController
    {
        private readonly IDbContext _db;

        public AdminController(IDbContext dbContext)
        {
            _db = dbContext;
        }

        public ActionResult Index()
        {
            return View(_db.Articles.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Article article = _db.Articles.Find(id);
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
                _db.Articles.Add(article);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(article);
        }

        public ActionResult Edit(int id = 0)
        {
            Article article = _db.Articles.Find(id);
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
                _db.SetModified(article);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(article);
        }

        public ActionResult Delete(int id = 0)
        {
            Article article = _db.Articles.Find(id);
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
            Article article = _db.Articles.Find(id);
            _db.Articles.Remove(article);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}