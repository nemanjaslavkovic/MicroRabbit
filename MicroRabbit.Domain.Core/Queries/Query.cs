using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Queries
{
    public abstract class Query<TResp> : IRequest<TResp>
    {
        public DateTime Timestamp { get; protected set; }

        public Query()
        {
            Timestamp = DateTime.Now;
        }
    }
}
