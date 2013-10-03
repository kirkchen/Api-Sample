namespace ApiSample.DA.Tables.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ApiSample.DA.Tables.ShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ApiSample.DA.Tables.ShopContext context)
        {
            context.Categories.AddOrUpdate(
                i => i.Name,
                new Category()
                {
                    Name = "¦WµP¥]¥]",
                    Categories = new List<Category>()
                    {
                        new Category() 
                        {
                            Name= "Gucci",
                            Products = new List<Product>() 
                            {
                                new Product()
                                {
                                    Name = "Gucci - 1",
                                    Price = 200,
                                    Cost = 100,                                     
                                    SellingStartTime = DateTime.Now,
                                    SellingEndTime = DateTime.Now.AddYears(1)
                                }
                            }
                        },
                        new Category() 
                        {
                            Name = "Prada",
                            Products = new List<Product>() 
                            {
                                new Product()
                                {
                                    Name = "Prada - 1",
                                    Price = 200,
                                    Cost = 100,                                     
                                    SellingStartTime = DateTime.Now,
                                    SellingEndTime = DateTime.Now.AddYears(1)
                                },
                                new Product()
                                {
                                    Name = "Prada - 2",
                                    Price = 200,
                                    Cost = 100,                                     
                                    SellingStartTime = DateTime.Now,
                                    SellingEndTime = DateTime.Now.AddYears(1)
                                }
                            }
                        }
                    }
                }
            );           
        }
    }
}
