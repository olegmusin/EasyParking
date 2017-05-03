using System.Collections.Generic;
using EasyParking.Dtos;

namespace EasyParking.ViewModels
{
    public class DesignViewModel
    {
        public string Moniker { get; set; }
        public int Columns { get; set; }
        public int Rows { get; set; }
        public ICollection<PlaceDto> Places { get; set; }
    }
}