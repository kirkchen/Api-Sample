using ApiSample.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Mappings
{
    public class GiftModelMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "GiftModelMappingProfile";
            }
        }

        protected override void Configure()
        {
            //// To GiftModel
            Mapper.CreateMap<string, GiftModel>()
                  .ConvertUsing(i =>
                  {
                      var giftData = i.Split(':');
                      var giftModel = new GiftModel();
                      giftModel.Name = giftData[0];
                      giftModel.Description = giftData[1];

                      return giftModel;
                  });

            Mapper.CreateMap<string, IEnumerable<GiftModel>>()
                  .ConvertUsing(i =>
                  {
                      var giftSourceList = i.Split(';');

                      return Mapper.Map<List<GiftModel>>(giftSourceList);
                  });
        }
    }
}
