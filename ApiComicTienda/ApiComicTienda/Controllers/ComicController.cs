using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicTienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ComicController : ControllerBase
    {

        private readonly IComicRepository comicRepository;
        public ComicController(IComicRepository comicRepository)
        {
            this.comicRepository = comicRepository;
        }
        [HttpGet]
        [Route("GetComics")]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics()
        {
            return StatusCode(StatusCodes.Status200OK,
                await comicRepository.GetComics());
        }

        [HttpGet]
        [Route("GetComics/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Comic>>> GetComics(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await comicRepository.GetComics(page, size));
        }


        [HttpGet]
        [Route("GetComicById/{id}")]
        public async Task<ActionResult<Comic>> GetComicsById(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await comicRepository.GetComicsById(id));
        }

        [HttpPost]
        [Route("CreateComic")]
        public async Task<ActionResult<Comic>> CreateComic(Comic comic)
        {
            return StatusCode(StatusCodes.Status201Created,
                await comicRepository.CreateComic(comic));
        }

        [HttpPut]
        [Route("UpdateComic")]
        public async Task<ActionResult<Comic>> UpdateComic(Comic comic)
        {
            return StatusCode(StatusCodes.Status200OK,
                await comicRepository.UpdateComic(comic));
        }
        [HttpDelete]
        [Route("DeleteComic")]
        public async Task<ActionResult<bool>> DeleteComic(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await comicRepository.DeleteComic(id));
        }
    }
}
