namespace Ordering.Infrastructure.Data.Extensions
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class DatabaseExtensions
    {
        public static async Task InitialiseDatabaseAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();

            var conntext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

            conntext.Database.MigrateAsync().GetAwaiter().GetResult();
        }
    }
}
