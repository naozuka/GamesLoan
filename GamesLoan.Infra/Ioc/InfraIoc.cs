using System;
using GamesLoan.Core.Interfaces;
using GamesLoan.Infra.Data.Context;
using GamesLoan.Infra.Data.Repositories;
using GamesLoan.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace GamesLoan.Infra.Ioc
{
    public static class InfraIoc
    {
        public static void InfraServicesIoc(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

            services.AddDbContext<AppDbContext>(options => 
            {
                options.UseSqlServer(connectionString, sqlServerOptionsAction: sqlOptions =>
                {                    
                    // Solve the problem for sql server container when it's not ready yet
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                });
            });            

            services.AddScoped<IHashService, HashService>();

            services.AddScoped<ILoginRepository, LoginRepository>();            
            services.AddScoped<IGameRepository, GameRepository>();
            services.AddScoped<IFriendRepository, FriendRepository>();
        }
    }
}