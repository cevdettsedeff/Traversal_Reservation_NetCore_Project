using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.Default
{
    public class _SubAboutPartial : ViewComponent
    {
        SubAboutManager subAboutManager = new SubAboutManager(new EfSubAboutDal());
        public IViewComponentResult Invoke()
        {

            var values = subAboutManager.TGetList();
            return View(values);
        }
    }
}
