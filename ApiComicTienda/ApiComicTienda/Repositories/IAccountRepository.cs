using ApiComicTienda.Models;

namespace ApiComicTienda.Repositories
{
    public interface IAccountRepository
    {
        Task<IEnumerable<Account>> GetAccounts();
        Task<IEnumerable<Account>> GetAccounts(int page, int size);
        Task<Account> GetAccountById(int id);
        Task<Account> CreateAccount(Account account);
        Task<Account> UpdateAccount(Account account);
        Task<bool> DeleteAccount(int id);
    }
}
