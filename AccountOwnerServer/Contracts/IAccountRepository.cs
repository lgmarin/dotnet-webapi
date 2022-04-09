using Entities;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    Task<IEnumerable<Account>> AccountsByOwner(Guid ownerId);
}