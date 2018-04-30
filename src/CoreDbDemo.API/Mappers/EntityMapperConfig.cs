using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CoreDbDemo.Model;

namespace CoreDbDemo.API.Mappers
{
    public class EntityMapperConfig : Profile
    {
        public EntityMapperConfig()
        {
            CreateMap<Model.Domain.Retailer, Model.Entity.RetailerDbo>();

            CreateMap<Model.Entity.RetailerDbo, Model.Domain.Retailer>();
        }
    }
}