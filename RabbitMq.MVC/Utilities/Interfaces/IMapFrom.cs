using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMq.MVC.Utilities.Interfaces
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());

        //public void Mapping(Profile profile) 
        //{ 
        //    profile.CreateMap(typeof(T), GetType()); 
        //}
    }
}
