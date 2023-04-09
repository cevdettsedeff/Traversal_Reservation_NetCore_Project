using MediatR;

namespace Traversal_Reservation_NetCore_Project.CQRS.Commands.GuideCommands
{
    public class AddGuideCommand:IRequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
