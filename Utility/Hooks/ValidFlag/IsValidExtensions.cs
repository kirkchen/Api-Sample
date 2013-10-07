using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ApiSample.Utility.Hooks.ValidFlag
{
    public static class IsValidExtensions
    {
        public static IQueryable<T> Valids<T>(this IDbSet<T> dbSet)
            where T : class, IIsValid
        {
            return dbSet.Where(i => i.IsValid);
        }
    }
}
