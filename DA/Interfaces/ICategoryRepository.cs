using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Interfaces
{
    public interface ICategoryRepository
    {
        bool IsCategoryExist(int categoryId);
    }
}
