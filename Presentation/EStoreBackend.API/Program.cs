using EStoreBackend.API.Helper;
using EStoreBackend.Application;
using EStoreBackend.Application.Exceptions;
using EStoreBackend.Infrastructure;
using EStoreBackend.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddOutputCache(options =>
{
    options.AddPolicy("Cache",policy =>
    {
        policy.Expire(TimeSpan.FromHours(2));
    });
});

builder.Services.AddScoped<CacheHelper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.ConfigureExceptionHandlingMiddleware();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseOutputCache();

app.MapControllers();

app.Run();
