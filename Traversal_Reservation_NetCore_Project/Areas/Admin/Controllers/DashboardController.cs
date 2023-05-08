using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
