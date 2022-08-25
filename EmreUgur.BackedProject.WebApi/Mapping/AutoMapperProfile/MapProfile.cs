using AutoMapper;
using EmreUgur.BackedProject.DTO.Dtos;
using EmreUgur.BackedProject.Entities.Concrete;

namespace EmreUgur.BackedProject.WebApi.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            #region Car - CarDtos
            CreateMap<Car, CarListDto>().ReverseMap();
            #endregion

            #region Vehicle - VehicleDtos
            CreateMap<Vehicle, VehicleListDto>().ReverseMap();
            #endregion

            #region Color - ColorDtos
            CreateMap<Color, ColorListDto>().ReverseMap();
            #endregion

            #region Wheel - WheelDtos
            CreateMap<Wheel, WheelListDto>().ReverseMap();
            #endregion

            #region Headlight - HeadlightDtos
            CreateMap<Headlight, HeadlightListDto>().ReverseMap();
            #endregion

            #region Boat - BoatDtos
            CreateMap<Boat, BoatListDto>().ReverseMap();
            #endregion

            #region Bus - BusDtos
            CreateMap<Bus, BusListDto>().ReverseMap();
            #endregion
        }
    }
}
