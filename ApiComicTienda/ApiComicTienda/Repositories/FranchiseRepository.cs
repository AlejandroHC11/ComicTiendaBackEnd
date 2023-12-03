using ApiComicTienda.Exceptions;
using ApiComicTienda.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiComicTienda.Repositories
{
    public class FranchiseRepository : IFranchiseRepository
    {
        private readonly DBComicTiendaContext dbContext;
        public FranchiseRepository(DBComicTiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        async public Task<Franchise> CreateFranchise(Franchise franchise)
        {
            dbContext.Franchises.Add(franchise);
            await dbContext.SaveChangesAsync();
            return franchise;
        }

        async public Task<bool> DeleteFranchise(int id)
        {
            var franchise = await dbContext.Franchises.FirstOrDefaultAsync(F => F.FranchiseId == id);
            if (franchise == null)
            {
                return false;
            }
            dbContext.Franchises.Remove(franchise);
            await dbContext.SaveChangesAsync();
            return true;
        }

        async public Task<IEnumerable<Franchise>> GetFranchise()
        {
            return await dbContext.Franchises.ToListAsync();
        }

        async public Task<IEnumerable<Franchise>> GetFranchise(int page, int size)
        {
            var result = await this.dbContext.Franchises
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("Franchise list is empty");
            }
            return result;
        }

        async public Task<Franchise> GetFranchiseById(int id)
        {
            var franchise = await dbContext.Franchises.Where(F => F.FranchiseId == id).FirstOrDefaultAsync();
            if (franchise == null)
            {
                throw new NotFoundException($"Franchise not found with id {id}");
            }
            return franchise;
        }

        async public Task<Franchise> UpdateFranchise(Franchise franchise)
        {
            dbContext.Franchises.Update(franchise);
            await dbContext.SaveChangesAsync();
            return franchise;
        }
    }
}
