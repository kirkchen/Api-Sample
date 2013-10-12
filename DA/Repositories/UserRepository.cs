using ApiSample.DA.Interfaces;
using ApiSample.DA.Tables;
using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApiSample.Utility.Hooks.ValidFlag;
using AutoMapper.QueryableExtensions;

namespace ApiSample.DA.Repositories
{
    public class UserRepository : IUserRepository
    {
        public ShopContext ShopContext { get; set; }

        public UserRepository(ShopContext context)
        {
            this.ShopContext = context;
        }

        public UserModel GetUserByToken(string token)
        {
            var user = this.ShopContext.Users
                                       .Valids()
                                       .Where(i => i.Token == token)
                                       .Project()
                                       .To<UserModel>()
                                       .First();

            return user;
        }
    }
}
