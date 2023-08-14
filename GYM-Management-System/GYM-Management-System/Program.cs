using GYM_Management_System.Data;
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

            string connString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services
                .AddDbContext<GymDbContext>
                (opions => opions.UseSqlServer(connString));

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

            app.Run();
        }
    }
}