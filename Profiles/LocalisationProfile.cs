using AutoMapper;
using WholeSaler.DTO;
using WholeSaler.Entity;

namespace WholeSaler.Profiles
{
    public class LocalisationProfile : Profile
    {
        public LocalisationProfile() {
            CreateMap<Localisation, LocalisationDTO>();
            CreateMap<LocalisationDTO, Localisation>();
        }
    }
}
