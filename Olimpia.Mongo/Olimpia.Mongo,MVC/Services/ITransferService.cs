using Olimpia.Mongo_MVC.Models;
using System.Threading.Tasks;

namespace Olimpia.Mongo_MVC.Services
{
    public interface ITransferService
    {
        Task Transfer(TransferDTO transderDTO);
    }
}
