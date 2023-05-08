using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.MemberLayout
{
    public class _MemberLayoutHeaderContent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
