using Entities;

namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    void CreateOwner(Owner owner);
    void DeleteOwner(Owner owner);
    IEnumerable<Owner> GetAllOwners();
    Owner GetOwnerById(Guid OwnerId);
    Owner GetOwnerWithDetails(Guid ownerId);
    void UpdateOwner(Owner owner);
}