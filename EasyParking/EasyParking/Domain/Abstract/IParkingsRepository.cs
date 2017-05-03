using System.Collections.Generic;
using EasyParking.Domain.Entities;

namespace EasyParking.Domain.Abstract
{
    public interface IParkingsRepository
    {
        ParkingArea GetParkingByMoniker(string moniker);
        IEnumerable<ParkingArea> GetAllParkings();
    }
}