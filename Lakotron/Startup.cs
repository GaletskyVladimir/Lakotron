using ApplicationServices.IRepository;
using ApplicationServices.IServices;
using ApplicationServices.Repository;
using ApplicationServices.Services;
using Lakotron.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Lakotron
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IPaymentService, PaymentService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IPaymentInfoReporitory, PaymentInfoReporitory>();

            services.AddControllersWithViews(options =>
            {
                options.Filters.Add(new LastVisitFilter());
            });
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

            app.Use(next => context =>
            {
                var kk = $"1. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}";
                return next(context);
            });

            app.UseRouting();

            app.Use(next => context =>
            {
                var tt = $"2. Endpoint: {context.GetEndpoint()?.DisplayName ?? "(null)"}";
                return next(context);
            });

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
