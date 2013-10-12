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
    public class UserMappingProfile : Profile
    {
        public override string ProfileName
        {
            get
            {
                return "UserMappingProfile";
            }
        }

        protected override void Configure()
        {
            Mapper.CreateMap<User, UserModel>()
                  .ForMember(i => i.Groups, s => s.MapFrom(i => i.Groups.Select(j => j.Name)));
        }
    }
}
