using CredidSystem.DB;
using CredidSystem.Extensions;
using CredidSystem.Profiles;
using CredidSystem.Repository.Implementation;
using CredidSystem.Repository.Interface;
using CredidSystem.Service.Implementation;
using CredidSystem.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace CredidSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CreditWebDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();


            builder.Services.AddRepositories();
            builder.Services.AddServices();


            builder.Services.AddAutoMapper(typeof(Program).Assembly);
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

            app.UseAuthorization();

            app.MapControllerRoute(
               name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");





            app.Run();
        }
    }
}
