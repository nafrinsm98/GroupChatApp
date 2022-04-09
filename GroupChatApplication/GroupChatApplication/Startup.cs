using GroupChat.BuisnessLayer;
using GroupChat.BuisnessLayer.Interface;
using GroupChat.DataLayer.Interface;
using GroupChat.DataLayer.Models;
using GroupChat.DataLayer.UnitOfWork;
using GroupChatApplication.Api.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GroupChat.BuisnessLayer.Utility;
using System.Reflection;

namespace GroupChatApplication
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
            services.AddControllers();
            services.AddAutoMapper(typeof(GroupChatProfile).GetTypeInfo().Assembly);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<GroupChatDbContext>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IGroupServices, GroupService>();
            services.AddScoped<IGroupMessageService, GroupMessageServices>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseMiddleware<ExceptionMiddleware>();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
