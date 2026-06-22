using System.Security.Authentication.ExtendedProtection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using TP1Gnasso.Data;
using TP1Gnasso.Data.Interfaces;
using TP1Gnasso.Data.Repositories;
using TP1Gnasso.Entities;
using TP1Gnasso.Service;
using TP1Gnasso.Service.Interfaces;
using TP1Gnasso.Service.Services;
using TP1Gnasso.Service.Validators;


namespace TP1Gnasso.IoC
{
    public static class DependencyInyectionContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            //var services = new ServiceCollection();
            services.AddDbContext<SportShoesDbContext>();

            services.AddScoped<ISportShoeRepository, SportShoeRepository>();
            services.AddScoped<ISportRepository, SportRepository>();
            services.AddScoped<ISizeRepository, SizeRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IGenreRepository,  GenreRepository>();

            services.AddScoped<ISportShoeService, SportShoeService>();
            services.AddScoped<ISportService, SportService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ISizeService, SizeService>();
            services.AddScoped<IGenreService, GenreService>();

            services.AddScoped<IValidator<SportShoe>, SportShoeValidator>();
            services.AddScoped<IValidator<Sport>, SportValidator>();
            services.AddScoped<IValidator<Brand>, BrandValidator>();
            services.AddScoped<IValidator<Size>, SizeValidator>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;





        }
    }
}
                      