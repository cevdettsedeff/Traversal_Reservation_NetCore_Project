using DataAccessLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Traversal_Reservation_NetCore_Project.CQRS.Queries.DestinationQueries;
using Traversal_Reservation_NetCore_Project.CQRS.Results.DestinationResults;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.DestinationHandlers
{
    public class GetAllDestinationQueryHandler
    {
        private readonly Context _context;

        public GetAllDestinationQueryHandler(Context context)
        {
            _context = context;
        }

        public List<GetAllDestinationQueryResult> Handle(/*GetAllDestinationQuery query*/)
        {
            var values = _context.Destinations.Select(x => new GetAllDestinationQueryResult()
            {
                id = x.DestinationID,
                capacity = x.Capacity,
                city = x.City,
                daynight = x.DayNight,
                price = x.Price,
            }).AsNoTracking().ToList();

            return values;
        }
    }
}
