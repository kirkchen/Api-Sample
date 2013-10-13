using ApiSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Interfaces
{
    public interface IUserService
    {
        UserModel GetUserByToken(string token);        
    }
}
