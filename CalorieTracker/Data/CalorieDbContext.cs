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
    }
}
