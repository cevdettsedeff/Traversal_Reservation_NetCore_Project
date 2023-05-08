using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.MemberDashboard
{
    public class _GuideList:ViewComponent
    {
        private readonly IGuideService _guideService;

        public _GuideList(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
    }
}
