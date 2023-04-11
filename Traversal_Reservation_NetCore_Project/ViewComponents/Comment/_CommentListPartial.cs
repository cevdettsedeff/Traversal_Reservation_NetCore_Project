using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Traversal_Reservation_NetCore_Project.ViewComponents.Comment
{
    public class _CommentListPartial:ViewComponent
    {
        ICommentService _commentService;

        public _CommentListPartial(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IViewComponentResult Invoke(int id)
        {
            var values = _commentService.TGetListCommentWithDestinationAndUser(id);
            int count =values.Count();
            ViewBag.count = count;
            return View(values);
        }
    }
}
