using AutoMapper;
using Entities;
using Entities.DTO;

namespace AccountOwnerServer;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Owner, OwnerDTO>();

        CreateMap<Account, AccountDTO>();

        CreateMap<OwnerCreateDTO, Owner>();

        CreateMap<OwnerUpdateDTO, Owner>();
    }  
}
