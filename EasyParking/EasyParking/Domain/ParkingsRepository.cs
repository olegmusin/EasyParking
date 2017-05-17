using System.Collections.Generic;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain
{
    public partial class Repository<TContext>
    {

        public ParkingArea GetParkingByMoniker(string moniker)
        {
            return GetOne<ParkingArea>(p => p.Moniker == moniker, includeProperties: "Places");
        }

        public IEnumerable<ParkingArea> GetAllParkings()
        {
            return GetAll<ParkingArea>(includeProperties: "Places,Location");
        }

     
    }
}
