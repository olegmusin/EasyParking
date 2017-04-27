using EasyParking.Domain.Abstract;

namespace EasyParking.Domain.Entities
{
    public class Vehicle  : Entity<string>
    {
       public string Number { get; set; }
       
    }
}
