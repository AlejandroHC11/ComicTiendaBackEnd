using ApiComicTienda.Exceptions;
using ApiComicTienda.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ApiComicTienda.Repositories
{
    public class ReceiptRepository : IReceiptRepository
    {
        private readonly DBComicTiendaContext dbContext;
        public ReceiptRepository(DBComicTiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        async public Task<Receipt> CreateReceipt(Receipt receipt)
        {
            dbContext.Receipts.Add(receipt);
            await dbContext.SaveChangesAsync();
            return receipt;
        }

        async public Task<bool> DeleteReceipt(int id)
        {
            var receipt = await dbContext.Receipts.FirstOrDefaultAsync(R => R.ReceiptId == id);
            if (receipt == null)
            {
                return false;
            }
            dbContext.Receipts.Remove(receipt);
            await dbContext.SaveChangesAsync();
            return true;
        }

        async public Task<IEnumerable<Receipt>> GetReceipts()
        {
            return await dbContext.Receipts.ToListAsync();
        }

        async public Task<IEnumerable<Receipt>> GetReceipts(int page, int size)
        {
            var result = await this.dbContext.Receipts
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("Receipt list is empty");
            }
            return result;
        }

        async public Task<Receipt> GetReceiptsById(int id)
        {
            var receipt = await dbContext.Receipts.Where(R => R.ReceiptId == id).FirstOrDefaultAsync();
            if (receipt == null)
            {
                throw new NotFoundException($"Receipt not found with id {id}");
            }
            return receipt;
        }

        async public Task<Receipt> UpdateReceipt(Receipt receipt)
        {
            dbContext.Receipts.Update(receipt);
            await dbContext.SaveChangesAsync();
            return receipt;
        }
    }
}
