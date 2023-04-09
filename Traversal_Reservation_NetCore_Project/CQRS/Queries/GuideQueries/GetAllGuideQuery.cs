using DocumentFormat.OpenXml.Office2010.ExcelAc;
using MediatR;
using System.Collections.Generic;
using Traversal_Reservation_NetCore_Project.CQRS.Results.GuideResults;

namespace Traversal_Reservation_NetCore_Project.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery:IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
