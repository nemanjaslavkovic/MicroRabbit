using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MicroRabbit.Banking.Api.Controllers
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

        //GET api/banking/id
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAccountById(int id)
        {
            var account = await _accountService.GetAccountByIdAsync(id);

            return Ok(account);
        }

        //GET api/banking
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _accountService.GetAccountsAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AccountTransfer accountTransfer)
        {
            await _accountService.Transfer(accountTransfer);
            return Ok(accountTransfer);
        }
    }
}
