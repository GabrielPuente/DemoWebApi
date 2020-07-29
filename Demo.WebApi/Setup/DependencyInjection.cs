using Demo.Infrastructure.Interfaces;
using Demo.Infrastructure.Repositories;
using Demo.Service.Interfaces;
using Demo.Service.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Demo.WebApi.Setup
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
