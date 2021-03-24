using MediatR;
using MicroRabbit.Domain.Core.Commands;
using MicroRabbit.Domain.Core.Events;
using MicroRabbit.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicroRabbit.Domain.Core.Bus
{
    public interface IEventBus
    {
        Task<bool> SendCommand<T>(T command) where T : Command;

        //Task<TResp> SendQueryAsyncTest<T, TResp>(T query) where T : Query<TResp>;
        Task<TResponse> SendQueryAsync<TResponse>(IRequest<TResponse> query);
        void Publish<T>(T @event) where T : Event;

        void Subscribe<T, TH>()
            where T : Event
            where TH : IEventHandler<T>;
    }
}
