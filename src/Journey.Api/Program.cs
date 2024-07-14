using Journey.Api.Filters;
using Journey.Application.UseCases.Activitys.Complete;
using Journey.Application.UseCases.Activitys.Delete;
using Journey.Application.UseCases.Activitys.Register;
using Journey.Application.UseCases.Trips.Delete;
using Journey.Application.UseCases.Trips.Get;
using Journey.Application.UseCases.Trips.Register;
using Journey.Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<JourneyDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<RegisterTripUseCase>();
builder.Services.AddTransient<GetAllTripsUseCase>();
builder.Services.AddTransient<GetTripByIdUseCase>();
builder.Services.AddTransient<DeleteByIdUseCase>();
builder.Services.AddTransient<RegisterActivityUseCase>();
builder.Services.AddTransient<DeleteActivityUseCase>();
builder.Services.AddTransient<CompleteActivityUseCase>();

builder.Services.AddMvc(config => config.Filters.Add(typeof(ExceptionFilter)));

builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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