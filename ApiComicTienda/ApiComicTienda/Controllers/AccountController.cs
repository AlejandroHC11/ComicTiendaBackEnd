using ApiComicTienda.Models;
using ApiComicTienda.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ApiComicTienda.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            this.accountRepository = accountRepository;
        }
        [HttpGet]
        [Route("GetAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccounts());
        }

        [HttpGet]
        [Route("GetAccounts/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccounts(page, size));
        }


        [HttpGet]
        [Route("GetAccountById/{id}")]
        public async Task<ActionResult<Account>> GetAccountByid(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccountById(id));
        }

        [HttpPost]
        [Route("CreateAccount")]
        public async Task<ActionResult<Account>> CreateAccount(Account account)
        {
            return StatusCode(StatusCodes.Status201Created,
                await accountRepository.CreateAccount(account));
        }

        [HttpPut]
        [Route("UpdateAccount")]
        public async Task<ActionResult<Account>> UpdateAccount(Account account)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.UpdateAccount(account));
        }
        [HttpDelete]
        [Route("DeleteAccount")]
        public async Task<ActionResult<bool>> DeleteAccount(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.DeleteAccount(id));
        }
    }
}
