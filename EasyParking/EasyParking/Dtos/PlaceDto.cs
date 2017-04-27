namespace EasyParking.Dtos
{
    public class PlaceDto
    {
        public int Row { get; set; }
        public int Column { get; set; }
        public bool IsParkingAllowed { get; set; }
    }
}