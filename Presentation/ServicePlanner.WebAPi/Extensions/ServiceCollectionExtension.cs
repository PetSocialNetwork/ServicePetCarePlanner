using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServicePlanner.DataEntityFramework.Repositories;
using ServicePlanner.DataEntityFramework;
using ServicePlanner.Domain.Interfaces;
using ServicePlanner.WebApi.Filters;
using ServicePlanner.Domain.Services;

namespace ServicePlanner.WebApi.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void ConfigureServices
            (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddInfrastructure(configuration);
            services.AddApplicationComponents(configuration);
        }

        public static void ConfigureMiddleware(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
        }

        private static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddValidatorsFromAssemblyContaining<Program>();
            services.AddControllers(options =>
            {
                options.Filters.Add<CentralizedExceptionHandlingFilter>();
            });

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlannerService", Version = "v1" });
            });
            services.AddHttpClient();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }

        private static void AddApplicationComponents(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRepositories(configuration);
            services.AddDomainServices();
        }

        private static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Postgres")));

            services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
            services.AddScoped<IPlannerRepository, PlannerRepository>();
        }

        private static void AddDomainServices(this IServiceCollection services)
        {
            services.AddScoped<PlannerService>();
        }
    }
}
