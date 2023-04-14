using AutoMapper;
using Booking.API.Ioc;
using Booking.Application.Mapper;
using Booking.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbBooking>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Database")));
builder.Services.AddControllers();


builder.Services.InjectionsExtensions(builder.Configuration);

var configurationDTO = new MapperConfiguration(x => x.AddProfile(new MapperToDTO()));
var configurationEntity = new MapperConfiguration(x => x.AddProfile(new MapperToEntity()));
IMapper mapperEntity = configurationDTO.CreateMapper();
IMapper mapperDto = configurationEntity.CreateMapper();
builder.Services.AddSingleton(mapperEntity);
builder.Services.AddSingleton(mapperDto);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
