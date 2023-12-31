using GYM_Management_System.Controllers;
using GYM_Management_System.Data;
using GYM_Management_System.Models;
using GYM_Management_System.Models.Interfaces;
using GYM_Management_System.Models.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace gym_management_system_front_end.Models
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

            builder.Services.AddScoped<IUser, IdentityUserService>();
            builder.Services.AddTransient<IGym, GymService>();
            builder.Services.AddTransient<IClient, ClientService>();
            builder.Services.AddTransient<ISubscriptionTier, SubscriptionTierService>();
            builder.Services.AddTransient<IGymEquipment, GymEquipmentsService>();
            builder.Services.AddTransient<IEmployee, EmployeeService>();
            builder.Services.AddTransient<ISupplement, SupplementService>();
            builder.Services.AddTransient<IEmail, EmailService>();
            builder.Services.AddTransient<IAzureBlobStorageService, AzureBlobStorageService>();
            builder.Services.AddTransient<IPaymentService, PaymentService>();
            builder.Services.AddTransient<SubscriptionTiersController>();
            builder.Services.AddHostedService<SubscriptionCheckBackgroundService>();
            builder.Services.AddScoped<jwtTokenServices>();



            builder.Services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = jwtTokenServices.GetValidationParameters(builder.Configuration);
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("createAdmin", policy => policy.RequireClaim("persmissions", "create"));
                options.AddPolicy("createEmployee", policy => policy.RequireClaim("persmissions", "create"));
                options.AddPolicy("updateAdmin", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("updateEmployee", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("updateClient", policy => policy.RequireClaim("persmissions", "update"));
                options.AddPolicy("deleteAdmin", policy => policy.RequireClaim("persmissions", "delete"));
                options.AddPolicy("deleteEmployee", policy => policy.RequireClaim("persmissions", "delete"));
                options.AddPolicy("readAdmin", policy => policy.RequireClaim("persmissions", "deposit"));
                options.AddPolicy("readEmployee", policy => policy.RequireClaim("persmissions", "deposit"));
                options.AddPolicy("readClient", policy => policy.RequireClaim("persmissions", "deposit"));
            });

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo()

                {
                    Title = "Gym-System",
                    Version = "v1",
                });
            });

            var app = builder.Build();

            // Use middleware for error handling
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = 500; // or another Status according to Exception Type
                    context.Response.ContentType = "application/json";

                    var error = context.Features.Get<IExceptionHandlerFeature>();
                    if (error != null)
                    {
                        var ex = error.Error;

                        var logger = app.Services.GetRequiredService<ILogger<Program>>();
                        logger.LogError(ex, "An error occurred");

                        await context.Response.WriteAsync(ex.Message);
                    }
                });
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger(options =>
            {
                options.RouteTemplate = "/api/{documentName}/swagger.json";
            });

            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/api/v1/swagger.json", "Gym-System");
                options.RoutePrefix = "";
            });

            app.MapGet("/", () => "Hello World!");
            app.MapControllers();
            app.Run();
        }
        //Merge
    }
}