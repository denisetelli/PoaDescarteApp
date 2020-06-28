using AutoMapper;
using Business.Services;
using Business.Services.Interfaces;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using Descarte.Mapping;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace WebApplicationWasteDisposal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddTransient<IItemServico, ItemServico>();
            services.AddTransient<IItemRepositorio, ItemRepositorio>();

            services.AddTransient<IRecicladorServico, RecicladorServico>();
            services.AddTransient<IRecicladorRepositorio, RecicladorRepositorio>();

            services.AddTransient<ICategoriaServico, CategoriaServico>();
            services.AddTransient<ICategoriaRepositorio, CategoriaRepositorio>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<DatabaseContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                using (var context = new DatabaseContext((DbContextOptions<DatabaseContext>)options.Options))
                    DatabaseInitializer.Initializer(context);
                services.AddSession();
            });

            services.AddAuthorization();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = "/Login/Index";
                        options.SlidingExpiration = true;
                        options.ExpireTimeSpan = TimeSpan.FromMinutes(10);
                    });

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile());
            });
            IMapper mapper = config.CreateMapper();

            services.AddSingleton(mapper);
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
