using ApiSample.DA.Tables.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.DA.Tables.DatabaseInitializer
{
    public class DefaultDataInitializer : MigrateDatabaseToLatestVersion<ShopContext, DefaultConfiguration>
    {
    }
}
