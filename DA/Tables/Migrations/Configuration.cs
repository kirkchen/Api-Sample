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
                i=>i.Name,
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
                                    SellingEndTime = DateTime.Now.AddYears(1),
                                    ListingStartTime = DateTime.Now,
                                    ListingEndTime = DateTime.Now.AddYears(1)
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
                                    SellingEndTime = DateTime.Now.AddYears(1),
                                    ListingStartTime = DateTime.Now,
                                    ListingEndTime = DateTime.Now.AddYears(1)
                                },
                                new Product()
                                {
                                    Name = "Prada - 2",
                                    Price = 200,
                                    Cost = 100,                                     
                                    SellingStartTime = DateTime.Now,
                                    SellingEndTime = DateTime.Now.AddYears(1),
                                    ListingStartTime = DateTime.Now,
                                    ListingEndTime = DateTime.Now.AddYears(1)
                                }
                            }
                        }
                    }
                }
            );

            context.Groups.AddOrUpdate(
                i => i.Name,
                new Group()
                {
                    Name = "Administrator",
                    Users = new List<User>()
                    {
                        new User(){
                            Name = "Kirk",
                            Email = "kirkchen@test.com",
                            Token = "123456",
                            EncryptKey = "1111",
                            SaltKey = "1111"
                        }
                    }
                }
            );

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
