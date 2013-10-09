using ApiSample.Models;
using ApiSample.ViewModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Mappings
{
    public class ProductModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "InsertProductModelProfile";
            }
        }

        protected override void Configure()
        {
            //// To ProductModel
            Mapper.CreateMap<InsertProductModel, ProductModel>()
                  .ForMember(i => i.Name, s => s.MapFrom(i => i.Name))
                  .ForMember(i => i.Price, s => s.MapFrom(i => i.Price))
                  .ForMember(i => i.Cost, s => s.MapFrom(i => i.Cost))
                  .ForMember(i => i.Description, s => s.MapFrom(i => i.Introduction))
                  .ForMember(i => i.ListingStartTime, s => s.MapFrom(i => i.StartListingAt))
                  .ForMember(i => i.ListingEndTime, s => s.MapFrom(i => i.FinishListingAt))
                  .ForMember(i => i.SellingStartTime, s => s.MapFrom(i => i.StartSellAt))
                  .ForMember(i => i.SellingEndTime, s => s.MapFrom(i => i.FinishSellAt))
                  .ForMember(i => i.CategoryId, s => s.MapFrom(i => i.CategoryId));

            //// To GiftModel
            Mapper.CreateMap<string, IEnumerable<GiftModel>>()
                  .ConvertUsing(i =>
                  {
                      var giftList = new List<GiftModel>();
                      var giftSourceList = i.Split(';');
                      foreach (var giftSource in giftSourceList)
                      {
                          var giftData = giftSource.Split(':');
                          var giftModel = new GiftModel();
                          giftModel.Name = giftData[0];
                          giftModel.Description = giftData[1];

                          giftList.Add(giftModel);
                      }

                      return giftList;
                  });
        }
    }
}
