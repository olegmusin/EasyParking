using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain.Abstract
{
    public interface IPlaceRepository
    {
        Place GetPlaceForParking(int row, int column, string moniker);
        IEnumerable<Place> GetAllPlacesForParking(string moniker);
    }
}
