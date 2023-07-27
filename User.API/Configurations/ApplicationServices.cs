using Microsoft.EntityFrameworkCore;
using User.Domain.Repository;
using User.Domain.UnitOfWork;
using User.Domain;
using User.API.Token;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using User.Application.Interface;
using User.Application.Services;
using static User.API.Protos.Token;

namespace User.API.Configurations
{
    public static class ApplicationServices
    {
        public static IServiceCollection AddCustomAuthentication(this IServiceCollection services)
        {
            var tokenKey = Encoding.UTF8.GetBytes("ABNM YE KJLK FD OPIL KLM AERIFY ERT OOKENS, REPLACE AB POIN YOUN OWN SECRET, IT HTR PO RET STWINC");
            var encryptionkey = Encoding.UTF8.GetBytes("qwsadfrewtyh4532");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                      .AddJwtBearer(x =>
                      {
                          x.RequireHttpsMetadata = false;
                          x.SaveToken = true;
                          x.TokenValidationParameters = new TokenValidationParameters
                          {
                              RequireExpirationTime = true,
                              ValidateLifetime = true,
                              ValidateIssuerSigningKey = true,
                              IssuerSigningKey = new SymmetricSecurityKey(tokenKey),
                              ValidateIssuer = false,
                              ValidateAudience = false,
                              TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)

                          };
                      });
            return services;

        }

        public static void AddCustomApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddGrpcClient<TokenClient>(o =>
            {
                o.Address = new Uri(configuration["GRPC_SERVER_ADDRESS"]);
            });
            services.AddDbContext<UserDBContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("UserDbConnection"));
            });
            services.AddTransient<UserDBContext>();
            services.AddTransient<ICreateToken, CreateToken>();
            services.AddTransient<UsersRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ISignUp,SignUp>();
            services.AddTransient<ILogin, Login>();
            services.AddTransient<IUserInfo, UserInfo>();
        }
    }
}
