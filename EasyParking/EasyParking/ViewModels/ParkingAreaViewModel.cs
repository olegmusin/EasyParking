using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using EasyParking.Dtos;

namespace EasyParking.ViewModels
{
    public class ParkingAreaViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Moniker { get; set; }

        public string ParkingOwner { get; set; }
        
        public string LocationAddress1 { get; set; }
        public string LocationAddress2 { get; set; }
        public string LocationAddress3 { get; set; }
        public string LocationCityTown { get; set; }
        public string LocationStateProvince { get; set; }
        public string LocationPostalCode { get; set; }
        public string LocationCountry { get; set; }

        public ICollection<PlaceDto> Places { get; set; }
    }
}
