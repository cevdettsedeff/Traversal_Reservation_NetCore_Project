using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic:ViewComponent
    {
        Context context = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.value1 = context.Destinations.Count();
            ViewBag.value2 = context.Users.Count();
            return View();
        }
    }
}
