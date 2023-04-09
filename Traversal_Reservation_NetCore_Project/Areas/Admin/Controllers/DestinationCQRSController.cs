using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommands;
using Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers;
using Traversal_Reservation_NetCore_Project.CQRS.Queries.DestinationQueries;

namespace Traversal_Reservation_NetCore_Project.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area(nameof(Admin))]
    [Route("Admin/[controller]/[action]/{id?}")]

    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly AddDestinationCommandHandler _addDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, AddDestinationCommandHandler addDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _addDestinationCommandHandler = addDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [HttpGet]
        public IActionResult GetDestination(int id)
        {
            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }

        [HttpPost]
        public IActionResult GetDestination(UpdateDestinationCommand updateDestinationCommand)
        {
            _updateDestinationCommandHandler.Handle(updateDestinationCommand);
            return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
        }

        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddDestination(AddDestinationCommand addDestinationCommand)
        {
            _addDestinationCommandHandler.Handle(addDestinationCommand);
            return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
        }

        public IActionResult DeleteDestination(int id)
        {
            _deleteDestinationCommandHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("Index", "DestinationCQRS", new { area = "Admin" });
        }
    }
}
