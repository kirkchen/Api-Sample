using ApiSample.BL.Interfaces;
using ApiSample.ViewModels;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSample.BL.Validators
{
        public class InsertProductModelValidator : AbstractValidator<InsertProductModel>
        {
            public ICategoryService CategoryService { get; set; }        

            public InsertProductModelValidator(ICategoryService categoryService)
            {
                this.CategoryService = categoryService;
            
                RuleFor(i => i.Name).NotEmpty()
                                    .Length(1, 100);

                RuleFor(i => i.Price).GreaterThan(0)
                                     .GreaterThan(i => i.Cost);

                RuleFor(i => i.Cost).GreaterThan(0)
                                    .LessThan(i => i.Price);            

                RuleFor(i => i.Introduction).Length(0, 1000);

                RuleFor(i => i.StartSellAt).NotEmpty()
                                           .LessThan(i => i.FinishSellAt);

                RuleFor(i => i.FinishSellAt).NotEmpty()
                                            .GreaterThan(i => i.StartSellAt);

                RuleFor(i => i.StartListingAt).NotEmpty()
                                              .LessThanOrEqualTo(i => i.StartSellAt);

                RuleFor(i => i.FinishListingAt).NotEmpty()
                                               .GreaterThanOrEqualTo(i => i.FinishSellAt);

                RuleFor(i => i.CategoryId).NotEmpty()
                                          .Must(i => this.CategoryService.IsCategoryExist(i))
                                          .WithMessage("Category must exist!");

            }
        }
}
