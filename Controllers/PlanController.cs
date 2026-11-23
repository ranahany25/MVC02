using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC02.Contexts;

namespace MVC02.Controllers
{
    public class PlanController : Controller
    {
        private GymDbContext dbContext = new();
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult>Index()
        {
            var plans=await dbContext.Plans.ToListAsync();
            return View(plans);
        }

    }
}
