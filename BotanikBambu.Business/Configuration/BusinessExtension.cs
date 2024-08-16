using BotanikBambu.Business.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using BotanikBambu.Business.Abstract;
using BotanikBambu.Business.Concrete;
using BotanikBambu.Business.Shared;
using BotanikBambu.Repository.Shared.Concrete;
using BotanikBambu.Repository.Shared.Abstract;
using Microsoft.Extensions.DependencyInjection;
namespace BotanikBambu.Business.Configuration
{
    public static class BusinessExtension
    {
        public static void BusinessDI(this IServiceCollection services)
        {
            services.AddScoped<IBambuService, BambuService>();
            services.AddScoped<ICartsService, CartsService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IGenderService, GenderService>();
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<ITruckerService,TruckerService>();
            services.AddScoped<IUserService, UserService>();

        }
        public static void RepositoryDI(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(IRepository<>));
        }
    }
}
