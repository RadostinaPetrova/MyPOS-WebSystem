namespace WebAppSystem.Seeding
{
    using System;
    using System.Threading.Tasks;
    using WebAppSystem.Data;

    public interface ISeeder
    {
        Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider);
    }
}
