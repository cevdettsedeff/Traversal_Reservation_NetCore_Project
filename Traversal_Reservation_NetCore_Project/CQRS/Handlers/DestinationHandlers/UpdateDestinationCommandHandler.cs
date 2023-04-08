using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommand;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand updateDestinationCommand)
        {
            var values = _context.Destinations.Find(updateDestinationCommand.DestinationId);
            values.City = updateDestinationCommand.City;
            values.DayNight = updateDestinationCommand.Daynight;
            values.Price = updateDestinationCommand.Price;
            values.Capacity = updateDestinationCommand.Capacity;
            values.Status = true;
            _context.SaveChanges();
        }
    }
}
