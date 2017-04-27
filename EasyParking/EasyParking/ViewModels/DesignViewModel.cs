using System.Collections.Generic;
using EasyParking.Dtos;

namespace EasyParking.ViewModels
{
    public class DesignViewModel
    {
        public string ParkingMoniker { get; set; }
        public int NumOfColumns { get; set; }
        public int NumOfRows { get; set; }
        public ICollection<PlaceDto> Lots { get; set; }
    }
}