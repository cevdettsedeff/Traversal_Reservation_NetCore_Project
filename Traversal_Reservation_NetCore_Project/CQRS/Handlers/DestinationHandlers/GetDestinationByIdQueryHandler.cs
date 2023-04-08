using DataAccessLayer.Concrete;
using Traversal_Reservation_NetCore_Project.CQRS.Queries.DestinationQueries;
using Traversal_Reservation_NetCore_Project.CQRS.Results.DestinationResults;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);
            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationID,
                City = values.City,
                Daynight = values.DayNight,
                Price = values.Price,
                Capacity = values.Capacity,
            };
        }
    }
}
