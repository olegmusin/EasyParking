using System.Collections.Generic;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain
{
    public partial class Repository<TContext>
    {

        public ParkingArea GetParkingByMoniker(string moniker)
        {
            return GetOne<ParkingArea>(p => p.Moniker == moniker);
        }

        public IEnumerable<ParkingArea> GetAllParkings()
        {
            return GetAll<ParkingArea>(includeProperties: "Location");
        }

        public IEnumerable<Place> GetAllPlacesForParking(string moniker)
        {
           return Get<Place>(pl => pl.Parking.Moniker == moniker);
        }

    }
}
