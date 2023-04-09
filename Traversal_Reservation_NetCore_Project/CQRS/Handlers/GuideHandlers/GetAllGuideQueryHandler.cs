using DataAccessLayer.Concrete;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.CQRS.Queries.GuideQueries;
using Traversal_Reservation_NetCore_Project.CQRS.Results.GuideResults;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.GuideHandlers
{
    public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
    {
        private readonly Context _context;

        public GetAllGuideQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
        {
            return await _context.Guides.Select(x => new GetAllGuideQueryResult
            {
                GuideID=x.GuideID,
                Description=x.Description,
                Image=x.Image,
                Name=x.Name,
            }).AsNoTracking().ToListAsync();
        }
    }
}
