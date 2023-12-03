using ApiComicTienda.Exceptions;
using ApiComicTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComicTienda.Repositories
{
    public class SalesDetailRepository : ISalesDetailRepository
    {
        private readonly DBComicTiendaContext dbContext;
        public SalesDetailRepository(DBComicTiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }

        async public Task<SalesDetail> CreateSaleDetail(SalesDetail salesDetail)
        {
            dbContext.SalesDetails.Add(salesDetail);
            await dbContext.SaveChangesAsync();
            return salesDetail;
        }

        async public Task<bool> DeleteSaleDetail(int id)
        {
            var salesDetail = await dbContext.SalesDetails.FirstOrDefaultAsync(S => S.SalesDetailId == id);
            if (salesDetail == null)
            {
                return false;
            }
            dbContext.SalesDetails.Remove(salesDetail);
            await dbContext.SaveChangesAsync();
            return true;
        }

        async public Task<SalesDetail> GetSaleDetailById(int id)
        {
            var salesDetail = await dbContext.SalesDetails.Where(S => S.SalesDetailId == id).FirstOrDefaultAsync();
            if (salesDetail == null)
            {
                throw new NotFoundException($"SalesDetail not found with id {id}");
            }
            return salesDetail;
        }

        async public Task<IEnumerable<SalesDetail>> GetSalesDetail()
        {
            return await dbContext.SalesDetails.ToListAsync();
        }

        async public Task<IEnumerable<SalesDetail>> GetSalesDetail(int page, int size)
        {
            var result = await this.dbContext.SalesDetails
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("SalesDetail list is empty");
            }
            return result;
        }

        async public Task<SalesDetail> UpdateSaleDetail(SalesDetail salesDetail)
        {
            dbContext.SalesDetails.Update(salesDetail);
            await dbContext.SaveChangesAsync();
            return salesDetail;
        }
    }
}
