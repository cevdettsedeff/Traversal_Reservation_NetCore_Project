using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        private readonly IDestinationService _destinationService;
        private readonly IGuideService _guideService;
        private readonly UserManager<AppUser> _userManager;

        public DestinationController(IDestinationService destinationService, IGuideService guideService, UserManager<AppUser> userManager)
        {
            _destinationService = destinationService;
            _guideService = guideService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }

        //[HttpGet]
        public async Task<IActionResult> DestinationDetails(int id)
        {

            ViewBag.id = id;
            ViewBag.destID = id;
            var value = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.userID = value.Id;
            var values = _destinationService.TGetDestinationWithGuide(id);
            return View(values);
        }

        //[HttpPost]
        //public IActionResult DestinationDetails(Destination destination)
        //{
        //    return View();
        //}
    }
}
