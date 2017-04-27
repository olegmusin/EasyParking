using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyParking.Domain.Abstract;

namespace EasyParking.Domain.Entities
{
    public class ParkingArea : Entity<string>
    {
        public string Moniker { get; set; }
        public Location Location { get; set; }
        public Owner Owner { get; set; }
        public virtual ICollection<Place> Places { get; set; }
    }
}
