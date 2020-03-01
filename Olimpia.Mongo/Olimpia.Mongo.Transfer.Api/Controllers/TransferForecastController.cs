using Microsoft.AspNetCore.Mvc;
using Olimpia.Mongo.Transfe.Domain.Models;
using Olimpia.Mongo.Transfer.Aplication.Interfaces;
using System.Collections.Generic;

namespace Olimpia.Mongo.Transfer.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ITransferService _transferService;

        public TransferController(ITransferService transferService)
        {
            _transferService = transferService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<TransferLog>> Get()
        {
            return Ok(_transferService.GetTransferLogs());
        }
    }
}
