using MediatR;
using Traversal_Reservation_NetCore_Project.CQRS.Results.GuideResults;

namespace Traversal_Reservation_NetCore_Project.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery:IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
