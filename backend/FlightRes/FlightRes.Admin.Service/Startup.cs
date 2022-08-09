using FlightRes.Data.DBContext;
using FlightRes.Data.Interface;
using FlightRes.Data.Interface.Admin;
using FlightRes.Data.Repositories.Admin;
using FlightRes.Data.Repositories.Common;
using FlightRes.Service;
using MassTransit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace FlightRes.Admin.Service
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

            services.AddCors(options =>
            options.AddPolicy(name: "AllowOrigin", builder =>
            builder.WithOrigins("http://localhost:4200").AllowAnyHeader().AllowAnyMethod()));

            services.AddControllers().AddNewtonsoftJson();
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            // .AddJwtBearer(Options =>
            // {
            //     Options.TokenValidationParameters = new TokenValidationParameters
            //     {
            //         ValidateIssuerSigningKey = true,
            //         IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
            //         .GetBytes(Configuration.GetSection("JwtConfig:secret").Value)),
            //         ValidateIssuer = false,
            //         ValidateAudience = false
            //     };
            // });
            
            services.AddScoped<IAirlineRepository, AirlineRepository>();
            services.AddTransient<IFlightRepository, FlightRepository>();
            services.AddConsulConfig(Configuration);
            services.AddDbContext<FlightResDBContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlightRes-Demo2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddMassTransit(x =>
            {
                //x.UsingRabbitMq();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    //configure.UseHealthCheck(provider);
                    configure.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                }));
            });
            //services.AddMassTransitHostedService();
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

            app.UseCors("AllowOrigin");

            app.UseConsul(Configuration);

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
