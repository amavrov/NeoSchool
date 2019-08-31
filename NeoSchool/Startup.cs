using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NeoSchool.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NeoSchool.Models;
using NeoSchool.Services;
using AutoMapper;
using CloudinaryDotNet;
using NeoSchool.Services.Mapping;

namespace NeoSchool
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                //This lambda determines whether user consent for non - essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;

            });

            services.AddDbContext<NeoSchoolDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddIdentity<User, UserRole>()
                    .AddEntityFrameworkStores<NeoSchoolDbContext>()
                    .AddDefaultTokenProviders();

            Account cloudinaryCredentials = new Account(
                 this.Configuration["Cloudinary:CloudName"],
                 this.Configuration["Cloudinary:ApiKey"],
                 this.Configuration["Cloudinary:ApiSecret"]);

            Cloudinary cloudinaryUtility = new Cloudinary(cloudinaryCredentials);

            services.AddSingleton(cloudinaryUtility);

            services.AddTransient<IVideoLessonService, VideoLessonService>();
            services.AddTransient<IMaterialService, MaterialService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICloudinaryService, CloudinaryService>();
            services.AddTransient<IDisciplineService, DisciplineService>();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Identity/Account/LogIn");


            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();


            //// Custom User Registration Options

            services.Configure<IdentityOptions>(options =>
            {
                
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;

                options.User.RequireUniqueEmail = true;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            AutoMapperConfig.RegisterMappings(typeof(VideoLesson).Assembly, typeof(VideoLessonViewModel).Assembly);


            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetRequiredService<NeoSchoolDbContext>())
                {
                    context.Database.Migrate();
                    #region Seeding
                    if (!context.Roles.Any())
                    {
                        context.Roles.Add(new UserRole { Name = "Admin", NormalizedName = "ADMIN" });
                        context.Roles.Add(new UserRole { Name = "Moderator", NormalizedName = "MODERATOR" });
                        context.Roles.Add(new UserRole { Name = "SuperUser", NormalizedName = "SUPERUSER" });
                        context.Roles.Add(new UserRole { Name = "User", NormalizedName = "USER" });
                    }

                    context.SaveChanges();
                    #endregion
                }
            }



            app.UseDeveloperExceptionPage();
            app.UseDatabaseErrorPage();
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvcWithDefaultRoute();


            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "areas",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
