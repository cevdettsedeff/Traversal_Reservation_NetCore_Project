﻿namespace Traversal_Reservation_NetCore_Project.CQRS.Commands.DestinationCommands
{
    public class AddDestinationCommand
    {
        public string City { get; set; }
        public string DayNight { get; set; }
        public double Price { get; set; }
        public int Capacity { get; set; }
    }
}