using Microsoft.AspNetCore.Mvc;
using Olimpia.Mongo.Bankin.Aplication.Interfaces;
using Olimpia.Mongo.Bankin.Aplication.Models;
using Olimpia.Mongo.Bankin.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Bankin.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BankingController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public BankingController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Account>> Get()
        {
            return Ok(_accountService.GetAccounts());
        }

        [HttpPost]
        public IActionResult Post([FromBody] AccountTransfer accountTransfer)
        {
            _accountService.Transfer(accountTransfer);

            return Ok(accountTransfer);
        }
    }
}
