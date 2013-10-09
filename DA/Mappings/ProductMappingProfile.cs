using ApiSample.DA.Tables;
using ApiSample.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Mappings
{
    public class ProductMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "ProductMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<ProductModel, Product>()
                  .ForMember(i => i.Name, s => s.MapFrom(i => i.Name))
                  .ForMember(i => i.Price, s => s.MapFrom(i => i.Price))
                  .ForMember(i => i.Cost, s => s.MapFrom(i => i.Cost))
                  .ForMember(i => i.Description, s => s.MapFrom(i => i.Description))
                  .ForMember(i => i.ListingStartTime, s => s.MapFrom(i => i.ListingStartTime))
                  .ForMember(i => i.ListingEndTime, s => s.MapFrom(i => i.ListingEndTime))
                  .ForMember(i => i.SellingStartTime, s => s.MapFrom(i => i.SellingStartTime))
                  .ForMember(i => i.SellingEndTime, s => s.MapFrom(i => i.ListingEndTime))
                  .ForMember(i => i.CategoryId, s => s.MapFrom(i => i.CategoryId))
                  .ForMember(i => i.Gifts, s => s.MapFrom(i => i.Gifts));

        }
    }
}
