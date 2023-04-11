using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    [AllowAnonymous]
    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }
    }
}
