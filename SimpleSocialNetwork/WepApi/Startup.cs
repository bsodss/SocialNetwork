using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using DAL.Entities;
using DAL.Identity;
using DAL.Interfaces;
using DAL.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace WepApi
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
            services.AddDbContext<SocialNetworkDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<SocialNetworkDbContext>();

            var mappperCfg = new MapperConfiguration(c =>
            {
                c.AddProfile(new AutomapperProfile());
            });
            IMapper mapper = mappperCfg.CreateMapper();
            services.AddSingleton(mapper);


            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<IUserAccountFriendRepository, UserAccountFriendRepository>();
            services.AddTransient<IUserAccountPostRepository, UserAccountPostRepository>();
            services.AddTransient<IFriendRequestRepository, FriendRequestRepository>();

            services.AddTransient<IIdentityManagers, IdentityManagers>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IUserAccountService, UserAccountService>();
            services.AddTransient<IUserService, UserService>();


            services.AddControllers();
        }


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
