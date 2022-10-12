using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(IPieRepository pieRepository) => this.pieRepository = pieRepository;

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = pieRepository.PiesOfTheWeek
            };

            return View(homeViewModel);
        }

        //

        private readonly IPieRepository pieRepository;
    }
}
