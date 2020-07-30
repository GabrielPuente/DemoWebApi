using TurtlePizzaria.Infrastructure.Interfaces;
using TurtlePizzaria.Infrastructure.Repositories;
using TurtlePizzaria.Service.Interfaces;
using TurtlePizzaria.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TurtlePizzaria.WebApi.Setup
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            //Context
            services.AddTransient<DbContext, DbContext>();

            //Services
            services.AddTransient<IUserService, UserService>();

            //Repositories
            services.AddTransient<IUserRepository, UserRepository>();

        }
    }
}
