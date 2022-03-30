using AccountOwnerServer.DTO;
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
    }  
}
