using AutoMapper;
using EasyParking.Domain.Entities;
using EasyParking.Dtos;

namespace EasyParking.ViewModels
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ParkingArea, ParkingAreaViewModel>()
                .ForMember(p => p.ParkingOwner, opt => opt.MapFrom(prk => prk.Owner.CompanyName))
                .ReverseMap()
                .ForMember(m => m.Location,
                    opt => opt.ResolveUsing(c => new Location()
                    {
                        Address1 = c.LocationAddress1,
                        Address2 = c.LocationAddress2,
                        Address3 = c.LocationAddress3,
                        CityTown = c.LocationCityTown,
                        StateProvince = c.LocationStateProvince,
                        PostalCode = c.LocationPostalCode,
                        Country = c.LocationCountry
                    }));
            CreateMap<Place, PlaceViewModel>().ReverseMap();
            CreateMap<Place, PlaceDto>().ReverseMap();
            CreateMap<ParkingArea, DesignViewModel>()
                .ForMember(vm => vm.ParkingMoniker, opt => opt.MapFrom(prk => prk.Moniker)).ReverseMap();
  
        }
    }
}
