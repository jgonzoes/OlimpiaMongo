using Olimpia.Mongo.Bankin.Aplication.Models;
using Olimpia.Mongo.Bankin.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Bankin.Aplication.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<Account> GetAccounts();

        void Transfer(AccountTransfer accountTransfer);
    }
}
