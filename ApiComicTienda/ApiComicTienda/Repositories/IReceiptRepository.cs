using ApiComicTienda.Models;

namespace ApiComicTienda.Repositories
{
    public interface IReceiptRepository
    {
        Task<IEnumerable<Receipt>> GetReceipts();
        Task<IEnumerable<Receipt>> GetReceipts(int page, int size);
        Task<Receipt> GetReceiptsById(int id);
        Task<Receipt> CreateReceipt(Receipt receipt);
        Task<Receipt> UpdateReceipt(Receipt receipt);
        Task<bool> DeleteReceipt(int id);
    }
}
