using BusinessLayer.Abstract;
using DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.Default
{
    public class _SliderPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _SliderPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _destinationService.TGetList();
            return View(values);
        }
    }
}
