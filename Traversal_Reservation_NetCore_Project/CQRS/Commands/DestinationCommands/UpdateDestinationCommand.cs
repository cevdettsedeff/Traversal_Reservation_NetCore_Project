namespace Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommands
{
    public class UpdateDestinationCommand
    {
        public int DestinationId { get; set; }
        public string City { get; set; }
        public string Daynight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}
