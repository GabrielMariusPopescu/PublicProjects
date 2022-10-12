using ExploreCalifornia.Entities;
using ExploreCalifornia.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace ExploreCalifornia.Controllers
{
    [Route("blog")]
    public class BlogController : Controller
    {
        public BlogController(BlogDataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public IActionResult Index(int page = 0)
        {
            var pageSize = 2;
            var totalPosts = dataContext.Posts.Count();
            var totalPages = totalPosts / pageSize;
            var previousPage = page - 1;
            var nextPage = page + 1;

            ViewBag.PreviousPage = previousPage;
            ViewBag.HasPreviousPage = previousPage >= 0;
            ViewBag.NextPage = nextPage;
            ViewBag.HasNextPage = nextPage < totalPages;

            var blogPosts = dataContext.Posts.OrderByDescending(post => post.Posted).Skip(pageSize * page).Take(pageSize).ToList();
            return View(blogPosts);
        }

        [Route("{year:min(2000)}/{month:range(1,12)}/{key}")]
        public IActionResult Post(int year, int month, string key)
        {
            var model = dataContext.Posts
                                   .Where(post => post.Key.Equals(key))
                                   .FirstOrDefault();
            return View(model);
        }

        [Authorize]
        [HttpGet, Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost, Route("Create")]
        public IActionResult Create(BlogPost model)
        {
            model.Author = User.Identity.Name;
            model.Posted = DateTime.Now;

            dataContext.Posts.Add(model);
            dataContext.SaveChanges();
            return RedirectToAction(
                "Post",
                "Blog",
                new
                {
                    year = model.Posted.Year,
                    month = model.Posted.Month,
                    key = model.Key
                });
        }

        //

        private readonly BlogDataContext dataContext;
    }
}
