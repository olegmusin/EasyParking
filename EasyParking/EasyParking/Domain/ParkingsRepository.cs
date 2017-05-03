using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using EasyParking.Domain.Abstract;
using Microsoft.EntityFrameworkCore;

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

        public IEnumerable<Place> GetAllPlacesForParking(string moniker)
        {
           return Get<Place>(pl => pl.Parking.Moniker == moniker);
        }

     
    }
}
