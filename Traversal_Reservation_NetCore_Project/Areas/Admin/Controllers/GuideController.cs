using BusinessLayer.Abstract;
using BusinessLayer.ValidationRules;
using EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area(nameof(Admin))]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class GuideController : Controller
    {
        private readonly IGuideService _guideService;

        GuideValidator validationRules = new GuideValidator();

        public GuideController(IGuideService guideService)
        {
            _guideService = guideService;
        }

        public IActionResult Index()
        {
            var values = _guideService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddGuide(Guide guide)
        {
            ValidationResult result = validationRules.Validate(guide);
            if (result.IsValid)
            {
                _guideService.TAdd(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" }); 
            }
            else
            {
                foreach(var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
            
        }

        [HttpGet]
        public IActionResult UpdateGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            return View(values);
        }

        [HttpPost]
        public IActionResult UpdateGuide(Guide guide)
        {
            ValidationResult result = validationRules.Validate(guide);
           
            if (result.IsValid)
            {
                _guideService.TUpdate(guide);
                return RedirectToAction("Index", "Guide", new { area = "Admin" }); 
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }

                return View();
            }
           
        }

        public IActionResult ChangeToTrue(int id)
        {
            _guideService.TChangeToTrueByGuide(id);
            return RedirectToAction("Index","Guide", new { area = "Admin"}); 
        }

        public IActionResult ChangeToFalse(int id)
        {
            _guideService.TChangeToFalseByGuide(id);
            return RedirectToAction("Index", "Guide", new { area = "Admin" }); 
        }

        public IActionResult DeleteGuide(int id)
        {
            var values = _guideService.TGetByID(id);
            _guideService.TDelete(values);
            return RedirectToAction("Index", "Guide", new { area = "Admin" }); 
        }

    }
}
