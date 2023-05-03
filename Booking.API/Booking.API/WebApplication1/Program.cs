using AutoMapper;
using Booking.API.Ioc;
using Booking.Application.Mapper;
using Booking.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DbBooking>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("Database")).UseLoggerFactory(LoggerFactory.Create(builder => { })));
builder.Services.AddControllers();


builder.Services.InjectionsExtensions(builder.Configuration);

IEnumerable<Profile> profiles = new List<Profile>
        {
           new MapperToEntity(),
           new MapperToDTO()
        };

var configurationDTO = new MapperConfiguration(x => x.AddProfiles(profiles));
IMapper mapperEntity = configurationDTO.CreateMapper();
builder.Services.AddSingleton(mapperEntity);

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
