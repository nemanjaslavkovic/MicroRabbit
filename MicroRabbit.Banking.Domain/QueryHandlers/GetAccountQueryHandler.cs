using MediatR;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Banking.Domain.Queries;
using MicroRabbit.Domain.Core.Bus;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.QueryHandlers
{
    public class GetAccountQueryHandler : IRequestHandler<GetAccountQuery, Account>
    {
        private readonly IAccountRepository _repository;

        public GetAccountQueryHandler(IAccountRepository repository)
        {
            _repository = repository;
        }

        public Task<Account> Handle(GetAccountQuery request, CancellationToken cancellationToken)
        {
            var output = _repository.GetAccountById(request.Id);
            return Task.FromResult(output);
        }
    }
}
