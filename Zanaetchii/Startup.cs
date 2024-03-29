using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Zanaetcii.Entities.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI;
using Zanaetchii.Contracts.Interfaces;
using Zanaetchii.Contracts.Services;
using Zanaetcii.Entities.Models;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using Zanaetchii.Profiles;

namespace Zanaetchii
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<MyDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
            );
            services.AddDbContext<UserDbContext>(options =>
           options.UseSqlServer(Configuration.GetConnectionString("IdentityConnection"))
           );

            services.AddIdentity<Users, ProjectRole>(cfg => {
                cfg.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<UserDbContext>();

            // registering all services
            services.AddScoped<IApplicationRepo, ApplicationRepo>();
            services.AddScoped<ICommentsRepo, CommentsRepo>();
            services.AddSingleton(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IRatingsRepo, RatingsRepo>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IWorkerRepo, WorkerRepo>();
            services.AddScoped<IWorkFieldsRepo, WorkFieldsRepo>();
            services.AddScoped<IWorkGiverRepo, WorkGiverRepo>();
            services.AddScoped<IWorkRepo, WorkRepo>();

            // auto mapper for the view models
            //services.AddAutoMapper(typeof(Startup));
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapingProfiles());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddControllersWithViews();
            services.AddRazorPages();
            //services.AddIdentity<Users, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
            //    .AddEntityFrameworkStores<MyDbContext>();

            //services.AddSingleton<IWorkFieldsRepo, WorkFieldsRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            
        }
    }
}
