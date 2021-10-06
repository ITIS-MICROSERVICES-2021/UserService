using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UserService.Cache;
using UserService.Core.Base.Validation;
using UserService.Core.Entities;
using UserService.Data;
using UserService.Features.UserManagement;

namespace UserService.WebHost
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
            services.AddDbContext<UserServiceDbContext>(builder => builder
                .UseNpgsql(Configuration.GetConnectionString("PostgresLocal")));
            services.AddIdentityCore<User>()
                .AddEntityFrameworkStores<UserServiceDbContext>();
            
            services.AddControllers()
                .AddApplicationPart(typeof(UserManagementController).Assembly)
                .AddNewtonsoftJson();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "UserService.WebHost", Version = "v1"});
            });
            services.AddHttpClient();
            services.AddAutoMapper(mc => { mc.AddMaps(typeof(UserManagementController).Assembly); });
            services.AddScoped<DbContext, UserServiceDbContext>();
            services.AddRedis(Configuration.GetConnectionString("Redis"), 1);
            RegisterMediaR(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "UserService.WebHost v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }

        private void RegisterMediaR(IServiceCollection services)
        {
            services.AddMediatR(typeof(UserManagementController).Assembly);
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssemblies(new[] {typeof(UserManagementController).Assembly});
        }
    }
}