using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Data;

public class CalorieDbContext : IdentityDbContext<Customer, CustomerRole, int>
{
    public DbSet<NutritionType> NutritionTypes { get; set; }
    public DbSet<Nutrition> Nutritions { get; set; }


    public CalorieDbContext(DbContextOptions<CalorieDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<NutritionType>().HasData(
            new NutritionType { Id = 1, Name = "Beyaz Et" },
            new NutritionType { Id = 2, Name = "Kırmızı Et" },
            new NutritionType { Id = 3, Name = "Deniz Mahsulleri" },
            new NutritionType { Id = 4, Name = "Süt Ürünleri" },
            new NutritionType { Id = 5, Name = "Kuru Gıdalar" });
    }

}