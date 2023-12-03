using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicTienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReceiptController : ControllerBase
    {
        private readonly IReceiptRepository receiptRepository;
        public ReceiptController(IReceiptRepository receiptRepository)
        {
            this.receiptRepository = receiptRepository;
        }
        [HttpGet]
        [Route("GetReceipts")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            return StatusCode(StatusCodes.Status200OK,
                await receiptRepository.GetReceipts());
        }

        [HttpGet]
        [Route("GetReceipts/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await receiptRepository.GetReceipts(page, size));
        }


        [HttpGet]
        [Route("GetReceiptById/{id}")]
        public async Task<ActionResult<Receipt>> GetReceiptByid(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await receiptRepository.GetReceiptsById(id));
        }

        [HttpPost]
        [Route("CreateReceipt")]
        public async Task<ActionResult<Receipt>> CreateReceipt(Receipt receipt)
        {
            return StatusCode(StatusCodes.Status201Created,
                await receiptRepository.CreateReceipt(receipt));
        }

        [HttpPut]
        [Route("UpdateReceipt")]
        public async Task<ActionResult<Receipt>> UpdateReceipt(Receipt receipt)
        {
            return StatusCode(StatusCodes.Status200OK,
                await receiptRepository.UpdateReceipt(receipt));
        }
        [HttpDelete]
        [Route("DeleteReceipt")]
        public async Task<ActionResult<bool>> DeleteReceipt(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await receiptRepository.DeleteReceipt(id));
        }
    }
}
