namespace WebAppSystem.Seeding
{
    using Microsoft.EntityFrameworkCore;
    using WebAppSystem.Data;

    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder Seeding(
            this IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                //dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
            }

            return app;
        }
    }
}
