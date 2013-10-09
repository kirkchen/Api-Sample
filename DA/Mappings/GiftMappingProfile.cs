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
        public class GiftMappingProfile : Profile
        {
            public override string ProfileName
            {
                get
                {
                    return "GiftMappingProfile";
                }
            }

            protected override void Configure()
            {
                Mapper.CreateMap<GiftModel, Gift>()
                      .ForMember(i => i.Name, s => s.MapFrom(i => i.Name))
                      .ForMember(i => i.Description, s => s.MapFrom(i => i.Description));
            }
        }
}
