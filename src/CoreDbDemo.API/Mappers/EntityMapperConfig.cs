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
            CreateMap<Model.Domain.Retailer, Model.Entity.RetailerDbo>().ReverseMap();

            CreateMap<Model.Domain.StaffMember, Model.Entity.StaffMemberDbo>().ReverseMap();

            CreateMap<Model.Domain.ExternalSystem, Model.Entity.ExternalSystemDbo>().ReverseMap();

            CreateMap<Model.Domain.AreaManager, Model.Entity.AreaManagerDbo>().ReverseMap();

            CreateMap<Model.Domain.Brand, Model.Entity.BrandDbo>().ReverseMap();

            CreateMap<Model.Domain.Request, Model.Entity.RequestDbo>().ReverseMap();
        }
    }
}