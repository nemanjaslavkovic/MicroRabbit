using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RabbitMq.MVC.Models;
using RabbitMq.MVC.Models.DTO;
using RabbitMq.MVC.Services.Interfaces;

namespace RabbitMq.MVC.Controllers
{
    public class BankingController : Controller
    {
        private readonly ILogger<BankingController> _logger;
        private readonly ITransferService _transferService;
        private readonly IMapper _autoMapper;

        public BankingController(ILogger<BankingController> logger, ITransferService transferService, IMapper autoMapper)
        {
            _logger = logger;
            _transferService = transferService;
            _autoMapper = autoMapper;
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDto transferDto = _autoMapper.Map<TransferDto>(model);

            await _transferService.Transfer(transferDto);

            //return RedirectToAction("Index");
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
