using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicTienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseRepository franchiseRepository;

        public FranchiseController(IFranchiseRepository franchiseRepository)
        {
            this.franchiseRepository = franchiseRepository;
        }

        [HttpGet]
        [Route("GetFranchises")]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises()
        {
            return StatusCode(StatusCodes.Status200OK,
                await franchiseRepository.GetFranchise());
        }

        [HttpGet]
        [Route("GetFranchises/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Franchise>>> GetFranchises(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await franchiseRepository.GetFranchise(page, size));
        }

        [HttpGet]
        [Route("GetFranchiseById/{id}")]
        public async Task<ActionResult<Franchise>> GetFranchiseById(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await franchiseRepository.GetFranchiseById(id));
        }

        [HttpPost]
        [Route("CreateFranchise")]
        public async Task<ActionResult<Franchise>> CreateFranchise(Franchise franchise)
        {
            return StatusCode(StatusCodes.Status201Created,
                await franchiseRepository.CreateFranchise(franchise));
        }

        [HttpPut]
        [Route("UpdateFranchise")]
        public async Task<ActionResult<Franchise>> UpdateFranchise(Franchise franchise)
        {
            return StatusCode(StatusCodes.Status200OK,
                await franchiseRepository.UpdateFranchise(franchise));
        }

        [HttpDelete]
        [Route("DeleteFranchise")]
        public async Task<ActionResult<bool>> DeleteFranchise(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await franchiseRepository.DeleteFranchise(id));
        }
    }
}
