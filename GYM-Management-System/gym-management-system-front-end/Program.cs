using gym_management_system_front_end.Controllers;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace gym_management_system_front_end
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddHttpClient();

            builder.Services.AddTransient<GymsController>();
            builder.Services.AddTransient<SupplementController>();
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                   options.LoginPath = "/User/Login"; // Set the login path
                   options.AccessDeniedPath = "/Account/auth/AccessDenied"; // Set the access denied path
               });
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication(); // Place UseAuthentication before UseAuthorization

            app.UseAuthorization();



            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}