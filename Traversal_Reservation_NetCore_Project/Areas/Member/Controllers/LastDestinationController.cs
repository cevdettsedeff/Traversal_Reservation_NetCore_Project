using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Areas.Member.Controllers
{
    
    [Area(nameof(Member))]
    public class LastDestinationController : Controller
    {
        private readonly IDestinationService _destinationService;

        public LastDestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IActionResult Index()
        {
            var values = _destinationService.TGetLastFourDestinations();
            return View(values);
        }
    }
}
