using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain
{
    public partial class Repository<TContext>
    {
        public Place GetPlaceForParking(int row, int column, string parkingId)
        {
            return Get<Place>(p => p.ParkingId == parkingId && p.Row == row && p.Column == column).First();
        }

        public IEnumerable<Place> GetAllPlacesForParking(string moniker)
        {
            throw new NotImplementedException();
        }
    }
}
