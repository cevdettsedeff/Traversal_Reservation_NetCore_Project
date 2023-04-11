using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Traversal_Reservation_NetCore_Project.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());

        private readonly UserManager<AppUser> _userManager;

        public CommentController( UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public PartialViewResult AddComment()
        {
            //ViewBag.destID = id;
            //var value = await _userManager.FindByNameAsync(User.Identity.Name);
            //ViewBag.userID = value.Id;
            return  PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {
            comment.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index","Destination");
        }
    }
}
