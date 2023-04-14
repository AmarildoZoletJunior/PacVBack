using Booking.Application.Interfaces;
using Booking.Application.Services;
using Booking.Data.Repositories;
using Booking.Data.UnitOfWork;
using Booking.Domain.Ports;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace Booking.API.Ioc
{
    public static class BookingExtensions
    {
        public static IServiceCollection InjectionsExtensions(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddScoped<IBookingRoomRepository,BookingRoomRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IClientService, ClientService>();

            var key = Encoding.ASCII.GetBytes(configuration["JwtToken"]);


            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });



            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    Description = "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                        "Digite 'Bearer' [espaço] e então seu token no campo abaixo.\r\n\r\n" +
                        "Exemplo (informar sem as aspas): 'Bearer 12345abcdef'",
                    BearerFormat = "JWT",


                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                 {
                      {
                         new OpenApiSecurityScheme
                             {
                                  Reference = new OpenApiReference
                                    {
                                         Type = ReferenceType.SecurityScheme,
                                         Id = "Bearer"
                                     },
                         Scheme = "oauth2",
                         Name = "Bearer",
                         In = ParameterLocation.Header,

                             },
                              new List<string>()
                      }
                });

            });

            return services;
        }
    }
}
