using HotelReservation.Application.Interfaces;
using HotelReservation.Application.Services;
using HotelReservation.Infrastructure.Data;
using HotelReservation.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using ultraGroup.Application;


var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddDbContext<HotelContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.Preserve;
    });

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<HotelService>();
builder.Services.AddScoped<ReservationService>();
builder.Services.AddScoped<RoomService>();
builder.Services.AddScoped<IRoomRepository, RoomRepository>();
builder.Services.AddScoped<IEmailService, EmailService>();
builder.Services.AddScoped<GuestService>();
builder.Services.AddScoped<IGuestRepository, GuestRepository>();
builder.Services.AddScoped<EmergencyContactService>();
builder.Services.AddScoped<IEmergencyContactRepository, EmergencyContactRepository>();

builder.Services.AddAuthorization();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
