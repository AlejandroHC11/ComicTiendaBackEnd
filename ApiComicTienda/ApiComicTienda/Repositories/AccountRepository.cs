using ApiComicTienda.Exceptions;
using ApiComicTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComicTienda.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly DBComicTiendaContext dbContext;
        public AccountRepository(DBComicTiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        async public Task<Account> CreateAccount(Account account)
        {
            dbContext.Accounts.Add(account);
            await dbContext.SaveChangesAsync();
            return account;
        }

        async public Task<bool> DeleteAccount(int id)
        {
            var account = await dbContext.Accounts.FirstOrDefaultAsync(A => A.AccountId == id);
            if (account == null)
            {
                return false;
            }
            dbContext.Accounts.Remove(account);
            await dbContext.SaveChangesAsync();
            return true;
        }

        async public Task<Account> GetAccountById(int id)
        {
            var account = await dbContext.Accounts.Where(A => A.AccountId == id).FirstOrDefaultAsync();
            if (account == null)
            {
                throw new NotFoundException($"Account not found with id {id}");
            }
            return account;
        }

        async public Task<IEnumerable<Account>> GetAccounts()
        {
            return await dbContext.Accounts.ToListAsync();
        }

        async public Task<IEnumerable<Account>> GetAccounts(int page, int size)
        {
            var result = await this.dbContext.Accounts
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("Account list is empty");
            }
            return result;
        }

        async public Task<Account> UpdateAccount(Account account)
        {
            dbContext.Accounts.Update(account);
            await dbContext.SaveChangesAsync();
            return account;
        }
    }
}
