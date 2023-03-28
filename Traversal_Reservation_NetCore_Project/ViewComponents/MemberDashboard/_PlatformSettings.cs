using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.MemberDashboard
{
    public class _PlatformSettings:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
