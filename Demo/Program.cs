using Demo.Authentcation;
using Demo.Models;
using Demo.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Demo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSession();
            builder.Services.AddDbContext <ITIEntity>(optionbuilder =>
            {
                optionbuilder.UseSqlServer (builder.Configuration.GetConnectionString("Db"));
            });
            
            builder.Services.AddScoped<IDeptRepo , DeptRepo>();
            builder.Services.AddScoped<ICrsRepo , CrsRepo>();
            builder.Services.AddScoped<IInstRepo , InstRepo>();
            builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<ITIEntity>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute("Inst",
                "Instructors",
                new
                {
                    controller = "Instructor",
                    action = "Index"

                });

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Product}/{action=VAll}/{id?}");

            app.Run();
        }
    }
}
