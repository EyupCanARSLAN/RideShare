
using Business.Interfaces;
using Business.Services;
using Domain;
using Domain.Repository;
using Domain.Repository.Interfaces;
using Domain.Repository.Repos;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DbConnectionString");
// Add services to the container.
builder.Services.AddDbContext<RideShareDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
