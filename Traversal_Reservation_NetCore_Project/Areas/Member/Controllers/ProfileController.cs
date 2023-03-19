using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Markup;
using Traversal_Reservation_NetCore_Project.Areas.Member.Models;

namespace Traversal_Reservation_NetCore_Project.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditViewModel user = new UserEditViewModel();
            user.name = values.Name;
            user.surname = values.Surname;
            user.phoneNumber = values.PhoneNumber;
            user.mail = values.Email;
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditViewModel user)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user.imageFile != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(user.imageFile.FileName);
                var imageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + imageName;
                var stream = new FileStream(saveLocation, FileMode.Create);
                await user.imageFile.CopyToAsync(stream);
                values.ImageUrl = imageName;
                }

            values.Name=user.name;
            values.Surname=user.surname;
            values.PhoneNumber=user.phoneNumber;
            values.PasswordHash = _userManager.PasswordHasher.HashPassword(values, user.password);
            var result = await _userManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();

        }

     }
}
