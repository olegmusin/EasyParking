using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.EquivalencyExpression;
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

            CreateMap<PlaceDto, Place>()
                .EqualityComparison((pdto, p) => pdto.Row == p.Row && pdto.Column == p.Column)
                .ReverseMap();

            CreateMap<ParkingArea, DesignViewModel>()
                .ForMember(vm => vm.Places, opt => opt.MapFrom(prk => prk.Places))
                .ForMember(vm => vm.Columns,
                    opt => opt.MapFrom(prk => prk.Places.Select(p => p.Column).Max()))
                .ForMember(vm => vm.Rows,
                    opt => opt.MapFrom(prk => prk.Places.Select(p => p.Row).Max()));


        }
    }
}
