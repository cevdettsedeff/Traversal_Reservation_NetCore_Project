using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    public class ErrorPageController : Controller
    {
        public IActionResult Error404(int code)
        {
            return View();
        }
    }
}
