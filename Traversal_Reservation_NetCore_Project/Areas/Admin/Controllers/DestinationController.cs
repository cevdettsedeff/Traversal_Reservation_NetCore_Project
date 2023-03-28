using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Update.Internal;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]

    public class DestinationController : Controller
    {
        DestinationManager destinationManager = new DestinationManager(new EfDestinationDal());
        public IActionResult Index()
        {
            var values = destinationManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(Destination destination)
        {
            destinationManager.TAdd(destination);
            return RedirectToAction("Index", "Destination", "Admin"); // yönlendirmeyi düzenle
        }

        public IActionResult DeleteDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            destinationManager.TDelete(values);
            return RedirectToAction("Index", "Destination", "Admin" ); // yönlendirmeyi düzenle
        }

        [HttpGet]
        public IActionResult UpdateDestination(int id)
        {
            var values = destinationManager.TGetByID(id);
            return View(values);
        }


        [HttpPost]
        public IActionResult UpdateDestination(Destination destination)
        {
            destinationManager.TUpdate(destination);
            return RedirectToAction("Index", "Destination", "Admin"); // yönlendirmeyi düzenle
        }
    }
}
