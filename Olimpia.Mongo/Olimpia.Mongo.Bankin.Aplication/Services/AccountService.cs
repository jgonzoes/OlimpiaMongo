using Olimpia.Mongo.Bankin.Aplication.Interfaces;
using Olimpia.Mongo.Bankin.Aplication.Models;
using Olimpia.Mongo.Bankin.Domain.Commands;
using Olimpia.Mongo.Bankin.Domain.Interfaces;
using Olimpia.Mongo.Bankin.Domain.Models;
using Olimpia.Mongo.Domain.core.Bus;
using System.Collections.Generic;

namespace Olimpia.Mongo.Bankin.Aplication.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IEventBus _bus;

        public AccountService(IAccountRepository accountRepository, IEventBus bus)
        {
            _accountRepository = accountRepository;
            _bus = bus;
        }

        public IEnumerable<Account> GetAccounts()
        {
            return _accountRepository.GetAccounts();
        }

        public void Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(
                accountTransfer.FromAccount,
                accountTransfer.ToAccount,
                accountTransfer.TransferAmount
            );

            _bus.SendCommand(createTransferCommand);
        }
    }
}
