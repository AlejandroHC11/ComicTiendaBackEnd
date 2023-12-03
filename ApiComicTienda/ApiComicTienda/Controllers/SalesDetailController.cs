using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicTienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalesDetailController : ControllerBase
    {

        private readonly ISalesDetailRepository salesDetailRepository;
        public SalesDetailController(ISalesDetailRepository salesDetailRepository)
        {
            this.salesDetailRepository = salesDetailRepository;
        }
        [HttpGet]
        [Route("GetSalesDetail")]
        public async Task<ActionResult<IEnumerable<SalesDetail>>> GetSalesDetail()
        {
            return StatusCode(StatusCodes.Status200OK,
                await salesDetailRepository.GetSalesDetail());
        }

        [HttpGet]
        [Route("GetSalesDetail/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<SalesDetail>>> GetSalesDetail(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await salesDetailRepository.GetSalesDetail(page, size));
        }


        [HttpGet]
        [Route("GetSaleDetailById/{id}")]
        public async Task<ActionResult<SalesDetail>> GetSaleDetailById(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await salesDetailRepository.GetSaleDetailById(id));
        }

        [HttpPost]
        [Route("CreateSaleDetail")]
        public async Task<ActionResult<SalesDetail>> CreateSaleDetail(SalesDetail salesDetail)
        {
            return StatusCode(StatusCodes.Status201Created,
                await salesDetailRepository.CreateSaleDetail(salesDetail));
        }

        [HttpPut]
        [Route("UpdateSaleDetail")]
        public async Task<ActionResult<SalesDetail>> UpdateSaleDetail(SalesDetail salesDetail)
        {
            return StatusCode(StatusCodes.Status200OK,
                await salesDetailRepository.UpdateSaleDetail(salesDetail));
        }
        [HttpDelete]
        [Route("DeleteSalesDetail")]
        public async Task<ActionResult<bool>> DeleteSalesDetail(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await salesDetailRepository.DeleteSaleDetail(id));
        }
    }
}
