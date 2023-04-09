namespace Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommands
{
    public class DeleteDestinationCommand
    {
        public DeleteDestinationCommand(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
