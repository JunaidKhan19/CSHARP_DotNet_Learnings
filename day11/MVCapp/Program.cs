using Microsoft.EntityFrameworkCore;
using MVCapp.Models;

namespace MVCapp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<EmpDbContext>(options => {
                options.UseSqlServer("name=connnectionStr"); //get the connectionString of db from appsettings.json
            }); //adding DbContext to the services container

            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    }
                );
                options.AddPolicy("policy1", 
                    (policydetails) => 
                    { 
                        policydetails.WithOrigins("http://example.com")
                                      .AllowAnyHeader()
                                      .AllowAnyMethod();
                    }
                );
            });

            var app = builder.Build();

            app.UseCors();

            //Middleware pipeline configuration
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );

            app.Run();
        }
    }
}
