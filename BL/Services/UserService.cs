using ApiSample.BL.Interfaces;
using ApiSample.DA.Interfaces;
using ApiSample.Models;
using ApiSample.Utility.Extensions.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Services
{
    public class UserService : IUserService
    {
        public IUserRepository UserRepository { get; set; }        

        public UserService(IUserRepository userRepository)
        {
            this.UserRepository = userRepository;
        }

        public UserModel GetUserByToken(string token)
        {
            return this.UserRepository.GetUserByToken(token);
        }
    }
}
