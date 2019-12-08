using ChoicesSuperMarket.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace ChoicesSuperMarket.Application.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<SubCategory> SubCategories { get; set; }
        DbSet<SubCategoryDiscount> SubCategoryDiscounts { get; set; }
        DbSet<CategoryDiscount> CategoryDiscounts { get; set; }
        DbSet<ProductDiscount> ProductDiscounts { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderItem> OrderItems { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}