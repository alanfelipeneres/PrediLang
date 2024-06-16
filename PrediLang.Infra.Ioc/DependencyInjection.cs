using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrediLang.Domain.Account;
using PrediLang.Domain.Interfaces;
using PrediLang.Infra.Data.Context;
using PrediLang.Infra.Data.Identity;
using PrediLang.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrediLang.Infra.Ioc
{
    public class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(
                option => option.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.AccessDeniedPath = "/Account/Login");

            services.AddScoped<ITemplateRepository, TemplateRepository>();
            services.AddScoped<IComplementoRepository, ComplementoRepository>();
            services.AddScoped<IRespostaRepository, RespostaRepository>();

            //services.AddScoped<IProductService, ProductService>();
            //services.AddScoped<ICategoryService, CategoryService>();

            services.AddScoped<IAuthenticate, AuthenticateService>();
            services.AddScoped<ISeedUserRoleInitial, SeedUserRoleInitial>();

            //services.AddAutoMapper(typeof(DomainToDtoMappingProfile));

            return services;
        }
    }
}
