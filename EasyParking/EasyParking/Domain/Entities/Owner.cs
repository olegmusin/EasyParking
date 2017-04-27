using System.Collections.Generic;
using EasyParking.Domain.Abstract;
using EasyParking.Domain.Identity;

namespace EasyParking.Domain.Entities
{
    public class Owner : Entity<string>
    {
        public string CompanyName { get; set; }
        public string PhoneNumber { get; set; }
        public string WebsiteUrl { get; set; }

        public AppUser User { get; set; }

        public ICollection<ParkingArea> Parkings { get; set; }
    }
}