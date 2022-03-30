using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;

namespace Repository;

public class AccountRepository : RepositoryBase<Account>, IAccountRepository
{
    public AccountRepository(RepositoryContext repositoryContext) : base(repositoryContext)
    {        
    }

}