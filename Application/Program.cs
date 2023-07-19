using Business.Interfaces.ServiceAggrigatorInterface;
using Business.Interfaces.ServiceInterface.TripServiceInterface;
using Business.ServiceAggrigator;
using Business.Services.TripService;
using Domain;
using Domain.Repository.Interfaces;
using Domain.Repository.Repos;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
// Add services to the container.
builder.Services.AddDbContext<RideShareDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory,
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
#region Repo Registiration
builder.Services.AddScoped<IPassangerRepository, PassengerRepository>();
builder.Services.AddScoped<ITripDetailRepository, TripDetailRepository>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
#endregion

#region Service Registiration
builder.Services.AddScoped<IFindTripService, FindTripService>();
builder.Services.AddScoped<ITripCreatorService, TripCreatorService>();
builder.Services.AddScoped<ITripReservationService, TripReservationService>();
builder.Services.AddScoped<ITripStatusService, TripStatusService>();
builder.Services.AddScoped<ITripServiceAggrigator, TripServiceAggrigator>();
#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();






app.Run();
