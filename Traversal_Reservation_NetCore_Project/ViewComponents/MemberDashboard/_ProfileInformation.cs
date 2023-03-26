using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.MemberDashboard
{
    public class _ProfileInformation
    {
        public class _FeaturePartial : ViewComponent
        {
            private readonly UserManager<AppUser> _userManager;

            public _FeaturePartial(UserManager<AppUser> userManager)
            {
                _userManager = userManager;
            }

            public async Task<IViewComponentResult> InvokeAsync()
            {
                var values = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.memberName = values.UserName + " " + values.Surname;
                ViewBag.memberPhone = values.PhoneNumber;
                ViewBag.memberMail = values.Email;
                return View();
            }
        }
    }
}
