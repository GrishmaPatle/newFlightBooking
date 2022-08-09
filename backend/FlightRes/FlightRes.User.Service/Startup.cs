using FlightRes.Data.DBContext;
using FlightRes.Data.Interface;
using FlightRes.Data.Interface.User;
using FlightRes.Data.Repositories;
using FlightRes.Data.Repositories.User;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FlightRes.Service;
using MassTransit;
using System;
using FlightRes.User.Service.Consumer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FlightRes.User.Service
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
            services.AddTransient<ISearchRepository, SearchRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IBookingRepository, BookingRepository>();
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddDbContext<FlightResDBContext>(options => options.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=FlightRes-Demo2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddConsulConfig(Configuration);
            services.AddMassTransit(x =>
            {               
                x.AddConsumer<AddedAirlinesConsume>();
                x.AddBus(provider => Bus.Factory.CreateUsingRabbitMq(configure =>
                {
                    configure.Host(new Uri("rabbitmq://localhost"), h =>
                    {
                        h.Username("guest");
                        h.Password("guest");
                    });

                    configure.ReceiveEndpoint("RabbitMqModel", oq =>
                     {
                         oq.PrefetchCount = 20;
                         oq.UseMessageRetry(r => r.Interval(2, 100));
                         oq.ConfigureConsumer<AddedAirlinesConsume>(provider);
                     });
                }));
            });           
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

            //app.UseAuthentication();

            app.UseAuthorization();

            app.UseConsul(Configuration);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
