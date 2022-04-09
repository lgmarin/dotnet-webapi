using Entities;

namespace Contracts;

public interface IOwnerRepository : IRepositoryBase<Owner>
{
    void CreateOwner(Owner owner);
    void DeleteOwner(Owner owner);
    Task<IEnumerable<Owner>> GetAllOwners();
    Task<Owner> GetOwnerById(Guid OwnerId);
    Task<Owner> GetOwnerWithDetails(Guid ownerId);
    void UpdateOwner(Owner owner);
}