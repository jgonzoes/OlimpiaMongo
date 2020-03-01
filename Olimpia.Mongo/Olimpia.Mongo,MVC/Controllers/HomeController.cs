using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Olimpia.Mongo_MVC.Models;
using Olimpia.Mongo_MVC.Services;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Olimpia.Mongo_MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITransferService _transferService;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, ITransferService transferService)
        {
            _logger = logger;
            _transferService = transferService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public async Task<IActionResult> Transfer(TransferViewModel model)
        {
            TransferDTO transferDTO = new TransferDTO()
            {
                FromAccount = model.FromAccount,
                ToAccount = model.ToAccount,
                TransferAmount = model.TransferAmount
            };

            await _transferService.Transfer(transferDTO);

            return View("Index");
        }
    }
}
