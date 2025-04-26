using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using ServicePlanner.DataEntityFramework;
using ServicePlanner.DataEntityFramework.Repositories;
using ServicePlanner.Domain.Interfaces;
using ServicePlanner.Domain.Services;
using ServicePlanner.WebApi.Filters;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<CentralizedExceptionHandlingFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "PlannerService", Version = "v1" });
});
builder.Services.AddHttpClient();

builder.Services.AddDbContext<AppDbContext>(options =>
   options.UseNpgsql(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped(typeof(IRepositoryEF<>), typeof(EFRepository<>));
builder.Services.AddScoped<IPlannerRepository, PlannerRepository>();
builder.Services.AddScoped<PlannerService>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
