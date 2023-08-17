using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace GYM_Management_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddControllers().AddNewtonsoftJson(options =>
      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
    );
            /// regstor the identty
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;

                // There are other options like this
            })
  .AddEntityFrameworkStores<GymDbContext>();
            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<GymDbContext>
                (opions => opions.UseSqlServer(connString));
            builder.Services.AddTransient<IUser, UserService>();
            builder.Services.AddTransient<IGym, GymService>();
            builder.Services.AddTransient<IClient, ClientService>();
            builder.Services.AddTransient<ISubscriptionTier, SubscriptionTierService>();
            builder.Services.AddTransient<IGymEquipment, GymEquipmentsService>();
			builder.Services.AddTransient<IEmployee, EmployeeService>();

			//------------ Swagger implementation -----------------------------------------------\\
			builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()

                {
                    Title = "Gym-System",
                    Version = "v1",
                });
            });



            var app = builder.Build();


            //------------ Swagger implementation -----------------------------------------------\\
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Gym-System");
                options.RoutePrefix = "docs";
            });

            app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.Run();
        }
    }
}