using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Areas.Member.Controllers
{
    
    [Area(nameof(Member))]
    
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
