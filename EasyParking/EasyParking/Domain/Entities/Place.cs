using EasyParking.Domain.Abstract;

namespace EasyParking.Domain.Entities
{
    public class Place : Entity<string>
    {
        public bool Booked { get; set; }
        public bool Occupied { get; set; }
        public bool IsParkingAllowed { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }
        public virtual ParkingArea Parking { get; set; }
    }

}