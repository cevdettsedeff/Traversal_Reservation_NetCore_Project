using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.GuideCommands;
using Traversal_Reservation_NetCore_Project.CQRS.Queries.GuideQueries;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [Area(nameof(Admin))]
    [AllowAnonymous]
    [Route("Admin/[controller]/[action]/{id?}")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> GetGuide(int id)
        {
            var values = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(values);
        }

        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddGuide(AddGuideCommand addGuideCommand)
        {
            await _mediator.Send(addGuideCommand);
            return RedirectToAction("Index", "GuideMediatR", new { area = "Admin" });
        }
    }
}
