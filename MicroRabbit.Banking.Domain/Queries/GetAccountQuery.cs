using MediatR;
using MicroRabbit.Banking.Domain.Models;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MicroRabbit.Banking.Domain.Queries
{
    public class GetAccountQuery : Query<Account>
    {
        public int Id { get; set; }

        public GetAccountQuery(int id)
        {
            Id = id;
        }
    }
}
