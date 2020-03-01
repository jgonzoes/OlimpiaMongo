using Microsoft.AspNetCore.Mvc;
using Olimpia.Mongo.TransferMongo.Aplication.Interfaces;
using Olimpia.Mongo_TransferMongo.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.TransferMongo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferController : ControllerBase
    {
        private readonly ITransferMongoService _transferService;

        public TransferController(ITransferMongoService transferService)
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