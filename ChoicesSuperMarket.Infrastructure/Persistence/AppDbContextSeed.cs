using ChoicesSuperMarket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Infrastructure.Persistence
{
    public static class AppDbContextSeed
    {
        public static async Task SeedAsync(AppDbContext context)
        {

            if(context.Customers.Any()) { return; }

            var categories = new Category[]
            {
                new Category("Produce"),
                new Category("Dairy")
            };

            var categoriesDiscount = new CategoryDiscount[]
            {
                new CategoryDiscount("10% off", 10, categories[0]),
                new CategoryDiscount("15% off", 15, categories[1])
            };

            var subCategories = new SubCategory[]
            {
                new SubCategory("Fruits", categories[0]),
                new SubCategory("Veg", categories[0]),
                new SubCategory("Milk", categories[1]),
                new SubCategory("Cheese", categories[1]),
            };
            var subCategoriesDiscount = new SubCategoryDiscount[]
            {
                new SubCategoryDiscount("18% off", 18, subCategories[0]),
                new SubCategoryDiscount("5% off", 5, subCategories[1]),
                new SubCategoryDiscount("20% off", 20, subCategories[2]),
                new SubCategoryDiscount("20% off", 20, subCategories[3]),
            };

            var products = new Product[]
            {
                new Product("Apple", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 50, "/img/apples.jpg", subCategories[0]),
                new Product("Orange", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 80, "/img/orange.jpg",subCategories[0]),
                new Product("Potato", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 30, "/img/potato.jpg",subCategories[1]),
                new Product("Tomato", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 70, "/img/tomato.jpg",subCategories[1]),
                new Product("Cow Milk", 1, Domain.Enums.EUnitOfMeasurement.Liter, 50, "/img/cow-milk.jpg",subCategories[2]),
                new Product("Soy Milk", 1, Domain.Enums.EUnitOfMeasurement.Liter, 40, "/img/soymilk.jpg",subCategories[2]),
                new Product("Cheddar", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 50, "/img/cheddar.jpg",subCategories[3]),
                new Product("Gouda", 1, Domain.Enums.EUnitOfMeasurement.Kilogram, 80, "/img/gouda.png",subCategories[3]),
            };

            var productDiscount = new ProductDiscount[]
            {
                new ProductDiscount("3Kg + 1Kg", 3, 1, products[0]),
                new ProductDiscount("20% off", 20, products[1]),
                new ProductDiscount("5Kg + 2Kg", 5,2,products[2]),
                new ProductDiscount("10% off", 10 , products[3]),
                new ProductDiscount("3Lt + 1Lt", 3, 2, products[4]),
                new ProductDiscount("10% off", 10, products[5]),
                new ProductDiscount("2Kg + 1Kg",2, 1, products[6]),
                new ProductDiscount("10% off",10, products[7])
            };
            var customer = new Customer("Anish Kumar", "anishkumar@xyz.com");


            await context.Categories.AddRangeAsync(categories);
            await context.CategoryDiscounts.AddRangeAsync(categoriesDiscount);
            await context.SubCategories.AddRangeAsync(subCategories);
            await context.SubCategoryDiscounts.AddRangeAsync(subCategoriesDiscount);

            await context.Products.AddRangeAsync(products);
            await context.ProductDiscounts.AddRangeAsync(productDiscount);

            await context.Customers.AddAsync(customer);

            await context.SaveChangesAsync(new System.Threading.CancellationToken());
        }
    }
}
