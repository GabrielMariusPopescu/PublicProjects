using ExploreCalifornia.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ExploreCalifornia.ViewComponents
{
    public class MonthlySpecials : ViewComponent
    {
        public MonthlySpecials(BlogDataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IViewComponentResult Invoke()
        {
            var specials = dataContext.MonthlySpecials.ToArray();
            return View(specials);
        }

        //

        private readonly BlogDataContext dataContext;
    }
}
