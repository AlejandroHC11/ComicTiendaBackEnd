using ApiComicTienda.Models;

namespace ApiComicTienda.Repositories
{
    public interface IComicRepository
    {
        Task<IEnumerable<Comic>> GetComics();
        Task<IEnumerable<Comic>> GetComics(int page, int size);
        Task<Comic> GetComicsById(int id);
        Task<Comic> CreateComic(Comic comic);
        Task<Comic> UpdateComic(Comic comic);
        Task<bool> DeleteComic(int id);
    }
}
