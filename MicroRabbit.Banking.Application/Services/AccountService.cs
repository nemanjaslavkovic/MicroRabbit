using MediatR;
using MicroRabbit.Banking.Application.Interfaces;
using MicroRabbit.Banking.Application.Models;
using MicroRabbit.Banking.Domain.Commands;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Domain.Queries;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _repository;
        private readonly IEventBus _eventBus;

        public AccountService(IAccountRepository repository, IEventBus eventBus, IMediator mediator)
        {
            _repository = repository;
            _eventBus = eventBus;
        }

        public async Task<Account> GetAccountByIdAsync(int accountId)
        {
            return await _eventBus.SendQueryAsync(new GetAccountQuery(accountId));
        }

        public async Task<IEnumerable<Account>> GetAccountsAsync()
        {
            return await _eventBus.SendQueryAsync(new GetAllAccountsQuery());
        }

        public async Task Transfer(AccountTransfer accountTransfer)
        {
            var createTransferCommand = new CreateTransferCommand(accountTransfer.FromAccount, accountTransfer.ToAccount, accountTransfer.TransferAmount);
            
            bool successfull = await _eventBus.SendCommand(createTransferCommand);

            if (!successfull)
            {
                //Log error
            }
        }
    }
}
