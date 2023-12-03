using ApiComicTienda.Models;

namespace ApiComicTienda.Repositories
{
    public interface IFranchiseRepository
    {
        Task<IEnumerable<Franchise>> GetFranchise();
        Task<IEnumerable<Franchise>> GetFranchise(int page, int size);
        Task<Franchise> GetFranchiseById(int id);
        Task<Franchise> CreateFranchise(Franchise franchise);
        Task<Franchise> UpdateFranchise(Franchise franchise);
        Task<bool> DeleteFranchise(int id);
    }
}
