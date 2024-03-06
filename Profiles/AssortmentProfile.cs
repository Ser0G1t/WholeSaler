using AutoMapper;
using WholeSaler.DTO;
using WholeSaler.Entity;

namespace WholeSaler.Profiles
{
    public class AssortmentProfile : Profile
    {
        public AssortmentProfile() {
            CreateMap<Assortment, AssortmentDTO>()
                .ForMember(dto => dto.id, assortment => assortment.MapFrom(assortment => assortment.AssortmentId));
            CreateMap<AssortmentDTO, Assortment>();
        }
    }
}
