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
    }
}