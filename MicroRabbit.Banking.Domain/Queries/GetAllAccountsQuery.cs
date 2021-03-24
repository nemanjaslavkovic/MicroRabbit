using MediatR;
using MicroRabbit.Banking.Domain.Interfaces;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MicroRabbit.Banking.Domain.Queries
{
    public class GetAllAccountsQuery : Query<IEnumerable<Account>>
    {
        public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, IEnumerable<Account>>
        {
            private readonly IAccountRepository _repository;

            public GetAllAccountsQueryHandler(IAccountRepository repository)
            {
                _repository = repository;
            }      

            public Task<IEnumerable<Account>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
            {
                var output = _repository.GetAccounts();
                return Task.FromResult(output);
            }
        }
    }
}
