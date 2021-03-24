using RabbitMq.MVC.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq.MVC.Services.Interfaces
{
    public interface ITransferService
    {
        Task Transfer(TransferDto transferDto);
    }
}
