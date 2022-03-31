using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class OwnerRepository : RepositoryBase<Owner>, IOwnerRepository
{
    public OwnerRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {
        
    }

    IEnumerable<Owner> IOwnerRepository.GetAllOwners()
    {
        return FindAll()
            .OrderBy(o => o.Name)
            .ToList();
    }

    public Owner GetOwnerById(Guid OwnerId)
    {
         return FindByCondition(owner => owner.Id.Equals(OwnerId))
            .FirstOrDefault();   
    }

    public Owner GetOwnerWithDetails(Guid ownerId)
    {
        return FindByCondition(owner => owner.Id.Equals(ownerId))
            .Include(ac => ac.Accounts)
            .FirstOrDefault();
    }

    public void CreateOwner(Owner owner)
    {
        Create(owner);
    }

    public void UpdateOwner(Owner owner)
    {
        Update(owner);
    }

    public void DeleteOwner(Owner owner)
    {
        Delete(owner);
    }
}