using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CalorieTracker.Data;

public class CalorieDbContext : IdentityDbContext<Customer, CustomerRole, int, CustomerClaim, CustomerRoleMapping, CustomerLogin, CustomerRoleClaim, CustomerToken>
{
    public DbSet<NutritionType> NutritionTypes { get; set; }
    public DbSet<Nutrition> Nutritions { get; set; }
    public DbSet<CustomerNutrition> CustomerNutritions { get; set; }


    public CalorieDbContext(DbContextOptions<CalorieDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);


        #region Identity Table Customizations

        builder.Entity<Customer>(entity =>
        {
            entity.ToTable(name: "Customer");
        });

        builder.Entity<CustomerRole>(entity =>
        {
            entity.ToTable(name: "CustomerRole");
        });

        builder.Entity<CustomerRoleMapping>(entity =>
        {
            entity.ToTable("CustomerRoles");
        });

        builder.Entity<CustomerClaim>(entity =>
        {
            entity.ToTable("CustomerClaims");
        });

        builder.Entity<CustomerLogin>(entity =>
        {
            entity.ToTable("CustomerLogins");
        });

        builder.Entity<CustomerRoleClaim>(entity =>
        {
            entity.ToTable("CustomerRoleClaims");
        });

        builder.Entity<CustomerToken>(entity =>
        {
            entity.ToTable("CustomerTokens");
        });
        #endregion

        #region Seed
        //Seeding a  'Administrator' role to AspNetRoles table
        builder.Entity<CustomerRole>().HasData(new CustomerRole
        {
            Id = 1,
            Name = "Administrator",
            NormalizedName = "ADMINISTRATOR".ToUpper()
        });

        //a hasher to hash the password before seeding the user to the db
        var hasher = new PasswordHasher<Customer>();

        //Seeding the User to AspNetUsers table
        builder.Entity<Customer>().HasData(
            new Customer
            {
                Id = 1,
                UserName = "hilal@hilal.com",
                Email = "hilal@hilal.com",
                Firstname = "Hilal",
                Lastname = "SÜT",
                Gender = Gender.Kadın,
                IsActive = true,
                LockoutEnabled = true,
                NormalizedEmail = "hilal@hilal.com".ToUpper(),
                NormalizedUserName = "hilal@hilal.com".ToUpper(),
                PasswordHash = hasher.HashPassword(null, "1234567890"),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        );

        builder.Entity<NutritionType>().HasData(
            new NutritionType { Id = 1, Name = "Beyaz Et" },
            new NutritionType { Id = 2, Name = "Kırmızı Et" },
            new NutritionType { Id = 3, Name = "Deniz Mahsulleri" },
            new NutritionType { Id = 4, Name = "Süt Ürünleri" },
            new NutritionType { Id = 5, Name = "Kuru Gıdalar" });

        builder.Entity<Nutrition>().HasData(
            new Nutrition
            {
                Id = 1,
                CreatedCustomerId = 1,
                NutritionTypeId = 1,
                Name = "Tavuk",
                Calorie = 215,
                AmountOfFat = 100,
                Cholesterol = 100,
                Protein = 100,
                Carbohydrate = 100,
            },
            new Nutrition
            {
                Id = 2,
                CreatedCustomerId = 1,
                NutritionTypeId = 3,
                Name = "Balık",
                Calorie = 215,
                AmountOfFat = 100,
                Cholesterol = 100,
                Protein = 100,
                Carbohydrate = 100,
            },
            new Nutrition
            {
                Id = 3,
                CreatedCustomerId = 1,
                NutritionTypeId = 2,
                Name = "Kuzu Çevirme",
                Calorie = 215,
                AmountOfFat = 100,
                Cholesterol = 100,
                Protein = 100,
                Carbohydrate = 100,
            }
        );
        #endregion
    }
}