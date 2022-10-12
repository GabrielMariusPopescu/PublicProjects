using BookList_v2._0.DataAccess.Contracts;
using BookList_v2._0.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace BookList_v2._0.Areas.Customer.Controllers
{
    [Area("Customer")]
    public class HomeController : Controller
    {
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            this.logger = logger;
            this.unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            var products = unitOfWork.ProductRepository.GetAll(includeProperties: "Category,Cover");

            return View(products);
        }
        public IActionResult Details()
        {
            throw new NotImplementedException();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //

        private readonly ILogger<HomeController> logger;
        private readonly IUnitOfWork unitOfWork;

    }
}
