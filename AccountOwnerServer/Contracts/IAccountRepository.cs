using Entities;

namespace Contracts;

public interface IAccountRepository : IRepositoryBase<Account>
{
    IEnumerable<Account> AccountsByOwner(Guid ownerId);
}