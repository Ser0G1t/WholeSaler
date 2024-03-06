using AutoMapper;
using WholeSaler.DTO;
using WholeSaler.Entity;

namespace WholeSaler.Profiles
{
    public class ContractorProfile : Profile
    {
        public ContractorProfile() { 
            CreateMap<User, UserAsContractorDTO>();
        }
    }
}
