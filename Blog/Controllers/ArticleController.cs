using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Controllers
{
    public class ArticleController : Controller
    {
        private readonly BlogContext _context;

        public ArticleController(BlogContext context)
        {
            _context = context;
        }

        public IActionResult ListArticle()
        {
            // categorilere göre filtrelemek için categorileri gösterdiğimiz alan
            //ViewBag.Categories = _context.Categories.ToList();
            ViewBag.Articles = _context.Articles.ToList();
            return View();
        }
        public IActionResult AddArticle()
        {
            // zaten bir model kullandığımız için burada viewbag ile veriyi gönderiyoruz.
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult AddArticle(ArticleViewModel model)
        {
            Article article = new Article();
            article.Content = model.ArticleContent;
            article.Title = model.ArticleTitle;
            article.Categories = new List<Category>();

            foreach (var item in model.Categories)
            {
                Category category = new Category { Id = item };
                _context.Categories.Attach(category);
                article.Categories.Add(category);
            }

            _context.Articles.Add(article);
            _context.SaveChanges();
            return RedirectToAction("ListArticle");
        }


    }
}
