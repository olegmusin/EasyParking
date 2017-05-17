using EasyParking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyParking.Domain.Abstract
{
    public interface IVechicleRepository
    {
        Vehicle GetVechiclebyNumber(string number);
        Task<Vehicle> GetCreateVechicle(string number);
    }
}
