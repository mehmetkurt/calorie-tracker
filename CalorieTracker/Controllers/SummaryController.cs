using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTracker.Controllers
{
    [Authorize]
    public class SummaryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
