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
        public Vehicle GetVechiclebyNumber(string number)
        {
            return GetOne<Vehicle>(v => v.Number == number);
        }

        public async Task<Vehicle> GetCreateVechicle(string number)
        {
            var car = GetVechiclebyNumber(number);
            if (car == null)
            {
                car = new Vehicle { Number = number };

                Create(car);

                if (await SaveAsync())
                    return car;
                throw new Exception("Can't create vechicle!");
            }
            return car;
        }

    }
}
