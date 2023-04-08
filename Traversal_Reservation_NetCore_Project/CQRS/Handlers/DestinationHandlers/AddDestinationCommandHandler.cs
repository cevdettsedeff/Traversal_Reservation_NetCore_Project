using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommand;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers
{
    public class AddDestinationCommandHandler
    {
        private readonly Context _context;

        public AddDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(AddDestinationCommand addDestinationCommand)
        {
            _context.Destinations.Add(new Destination
            {
                City = addDestinationCommand.City,
                Price = addDestinationCommand.Price,
                DayNight = addDestinationCommand.DayNight,
                Capacity = addDestinationCommand.Capacity,
                Status=true
            });
            _context.SaveChanges();
        }
    }
}
