using ApiComicTienda.Exceptions;
using ApiComicTienda.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Principal;

namespace ApiComicTienda.Repositories
{
    public class ComicRepository : IComicRepository
    {
        private readonly DBComicTiendaContext dbContext;
        public ComicRepository(DBComicTiendaContext dbContext)
        {
            this.dbContext = dbContext;
        }
        async public Task<Comic> CreateComic(Comic comic)
        {
            dbContext.Comics.Add(comic);
            await dbContext.SaveChangesAsync();
            return comic;
        }

        async public Task<bool> DeleteComic(int id)
        {
            var comic = await dbContext.Comics.FirstOrDefaultAsync(C => C.ComicId == id);
            if (comic == null)
            {
                return false;
            }
            dbContext.Comics.Remove(comic);
            await dbContext.SaveChangesAsync();
            return true;
        }

        async public Task<IEnumerable<Comic>> GetComics()
        {
            return await dbContext.Comics.ToListAsync();
        }

        async public Task<IEnumerable<Comic>> GetComics(int page, int size)
        {
            var result = await this.dbContext.Comics
            .Skip(page * size)
            .Take(size)
            .ToListAsync();
            if (result == null)
            {
                throw new Exception();
            }
            else if (result.Count == 0)
            {
                throw new NotFoundException("Comic list is empty");
            }
            return result;
        }

        async public Task<Comic> GetComicsById(int id)
        {
            var comic = await dbContext.Comics.Where(C => C.ComicId == id).FirstOrDefaultAsync();
            if (comic == null)
            {
                throw new NotFoundException($"Comic not found with id {id}");
            }
            return comic;
        }

        async public Task<Comic> UpdateComic(Comic comic)
        {
            dbContext.Comics.Update(comic);
            await dbContext.SaveChangesAsync();
            return comic;
        }
    }
}
