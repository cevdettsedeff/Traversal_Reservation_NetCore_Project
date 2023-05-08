using BusinessLayer.Abstract;
using DocumentFormat.OpenXml.Spreadsheet;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq.Expressions;
using Traversal_Reservation_NetCore_Project.Models;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    public class CityController : Controller
    {
        private readonly IDestinationService _destinationService;

        public CityController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_destinationService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Destination destination)
        {
            _destinationService.TAdd(destination);
            var values = JsonConvert.SerializeObject(destination);
            return Json(values);
        }

        
        public IActionResult GetById(int DestinationID)
        {
            var values = _destinationService.TGetByID(DestinationID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }


        public IActionResult DeleteCity(int id)
        {
            var values = _destinationService.TGetByID(id);
            _destinationService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Destination destination)
        {
            _destinationService.TUpdate(destination);

            var jsonValues = JsonConvert.SerializeObject(destination);
            return Json(jsonValues);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass()
        //    {
        //        CityId=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass()
        //    {
        //        CityId=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    }
        //};


    }
}
