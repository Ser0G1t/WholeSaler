using AutoMapper;
using WholeSaler.DTO;
using WholeSaler.Entity;

namespace WholeSaler.Profiles
{
    public class OrderProfile : Profile
    {
         public OrderProfile() {
            CreateMap<Order, OrderGetDTO>()
                .ForMember(dto => dto.CompanyName, order => order.MapFrom(order => order.User.CompanyName))
                .ForMember(dto => dto.NIP, order => order.MapFrom(order => order.User.NIP))
                .ForMember(dto => dto.Country, order => order.MapFrom(order => order.User.Country))
                .ForMember(dto => dto.PostCode, order => order.MapFrom(order => order.User.PostCode))
                .ForMember(dto => dto.City, order => order.MapFrom(order => order.User.City))
                .ForMember(dto => dto.Street, order => order.MapFrom(order => order.User.Street))
                .ForMember(dto => dto.Address, order => order.MapFrom(order => order.User.Address))
                .ForMember(dto => dto.PhoneNumber, order => order.MapFrom(order => order.User.PhoneNumber));
            CreateMap<OrderCreateDTO, Order>();
         }
    }
}
