using AutoMapper;
using RabbitMq.MVC.Utilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq.MVC.Models.DTO
{
    public class TransferDto : IMapFrom<TransferViewModel>
    {
        public int FromAccount { get; set; }

        public int ToAccount { get; set; }
        public decimal TransferAmount { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<TransferViewModel, TransferDto>();
        }
    }
}
