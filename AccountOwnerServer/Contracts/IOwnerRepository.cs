using Entities;

namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    void CreateOwner(Owner owner);
    void DeleteOwner(Owner owner);
    IEnumerable<Owner> GetAllOwners();
    Owner GetOwnerById(Guid OwnerId);
    void UpdateOwner(Owner owner);
}