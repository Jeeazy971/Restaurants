using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

namespace Restaurants.API;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddInfrastructure(builder.Configuration);

        builder.Services.AddControllers();

        var app = builder.Build();

        var scoped = app.Services.CreateScope();
        var seeder = scoped.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

        await seeder.Seed();

        // Configure the HTTP request pipeline.

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}
