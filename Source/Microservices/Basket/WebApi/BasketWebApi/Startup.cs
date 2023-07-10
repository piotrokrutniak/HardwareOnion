using Application;
using Application.Identity;
using Infrastructure.Persistence;
using Infrastructure.Shared;
using System.Text.Json.Serialization;
using WebApi.Extensions;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApi.Services;
using Infrastructure.Persistence.Contexts;
using Infrastructure.Shared.Services;

namespace WebApi
{
    public class Startup
    {
        public IConfiguration _config { get; }
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplicationLayer();
            services.AddCors();
            //services.AddSharedInfrastructure(_config);
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddIdentityLayer(_config);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IAuthenticatedUserService, AuthenticatedUserService>();
            services.AddPersistenceInfrastructure(_config);
            services.AddTransient<ApplicationDbContext>();
            services.AddSwaggerExtension();
            services.AddApiVersioningExtension();
            services.AddControllers()
                    .AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
            services.AddHealthChecks();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
            app.UseCors(corsPolicyBuilder => corsPolicyBuilder
              .WithOrigins("http://localhost:3000")
              .AllowAnyMethod()
              .AllowAnyHeader()
            );
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSwaggerExtension();
            app.UseErrorHandlingMiddleware();
            app.UseHealthChecks("/health");
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
