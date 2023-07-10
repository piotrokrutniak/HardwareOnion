using Ocelot.DependencyInjection;
using Ocelot.Middleware;

public class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables();

        //Services
        builder.Services.AddOcelot(builder.Configuration);
        builder.Services.AddCors();

        var app = builder.Build();

        app.UseCors(corsPolicyBuilder => corsPolicyBuilder
                      .WithOrigins("http://localhost:3000")
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                    );

        await app.UseOcelot();


        app.Run();
    }
}