using DataAccessLayer.Concrete;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommand;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteDestinationCommand deleteDestinationCommand)
        {
            var values = _context.Destinations.Find(deleteDestinationCommand.Id);
            _context.Destinations.Remove(values);
            _context.SaveChanges();
        }
    }
}
