using Dic.GraphQL.Demo.Contracts;
using Dic.GraphQL.Demo.Entities;
using Dic.GraphQL.Demo.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace Dic.GraphQL.Demo.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<ILookup<Guid, Account>> GetAccountsByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId)=>_context.Accounts
            .Where(a=>a.OwnerId.Equals(ownerId))
            .ToList();
    }
}
