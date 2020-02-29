using Olimpia.Mongo.Bankin.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Bankin.Domain.Interfaces
{
    public interface IAccountRepository
    {
        IEnumerable<Account> GetAccounts();
    }
}
