using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.Default
{
    public class _PopularDestinationPartial:ViewComponent
    {
        private readonly IDestinationService _destinationService;

        public _PopularDestinationPartial(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        public IViewComponentResult Invoke()
        {
            
            var values = _destinationService.TGetByFilter(x=>x.Image.Length > 5);
            return View(values);
        }
    }
}
