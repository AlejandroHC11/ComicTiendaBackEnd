using ApiComicTienda.Models;

namespace ApiComicTienda.Repositories
{
    public interface ISalesDetailRepository
    {
        Task<IEnumerable<SalesDetail>> GetSalesDetail();
        Task<IEnumerable<SalesDetail>> GetSalesDetail(int page, int size);
        Task<SalesDetail> GetSaleDetailById(int id);
        Task<SalesDetail> CreateSaleDetail(SalesDetail salesDetail);
        Task<SalesDetail> UpdateSaleDetail(SalesDetail salesDetail);
        Task<bool> DeleteSaleDetail(int id);
    }
}
