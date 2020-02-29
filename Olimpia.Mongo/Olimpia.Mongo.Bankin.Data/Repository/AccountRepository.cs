using Olimpia.Mongo.Bankin.Data.Context;
using Olimpia.Mongo.Bankin.Domain.Interfaces;
using Olimpia.Mongo.Bankin.Domain.Models;
using System.Collections.Generic;

namespace Olimpia.Mongo.Bankin.Data.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private BankingDbContext _ctx;

        public AccountRepository(BankingDbContext ctx)
        {
            _ctx = ctx;
        }
        public IEnumerable<Account> GetAccounts()
        {
            return _ctx.Accounts;
        }
    }
}
