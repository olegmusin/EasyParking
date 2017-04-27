using System;
using EasyParking.Domain.Abstract;

namespace EasyParking.Domain.Entities
{
    public class ParkingSession : Entity<string>
    {  
        public DateTime StartTime { get; set; }
        public DateTime ExitTime { get; set; }
        public Vehicle Vehicle { get; set; }
        public Place Place { get; set; }
        public ParkingArea Parking { get; set; }
    }
}
