using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Traversal_Reservation_NetCore_Project.CQRS.Commands.GuideCommands;

namespace Traversal_Reservation_NetCore_Project.CQRS.Handlers.GuideHandlers
{
    public class AddGuideCommandHandler : IRequestHandler<AddGuideCommand>
    {
        private readonly Context _context;
        public async Task<Unit> Handle(AddGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Name = request.Name,
                Description = request.Description,
                Status = true
            });
            await _context.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
