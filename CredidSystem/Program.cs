using CredidSystem.DB;
using CredidSystem.Entity;
using CredidSystem.Extensions;
using CredidSystem.Helpers;
using CredidSystem.Helpers.MailSettings;
using CredidSystem.Profiles;
using CredidSystem.Repository.Implementation;
using CredidSystem.Repository.Interface;
using CredidSystem.Service;
using CredidSystem.Service.Implementation;
using CredidSystem.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NETCore.MailKit.Core;
using System.Threading.Tasks;
using EmailService = CredidSystem.Service.EmailService;

namespace CredidSystem
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CreditWebDB>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

            builder.Services.AddIdentity<User, IdentityRole>(opt =>
            {
                opt.SignIn.RequireConfirmedAccount = false;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequiredLength = 8;
                opt.Password.RequireDigit = true;
                opt.Password.RequireLowercase = false;
                opt.User.RequireUniqueEmail = true;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<CreditWebDB>()
                .AddDefaultTokenProviders();

            builder.Services.Configure<EmailSettings>(
            builder.Configuration.GetSection("EmailSettings"));


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
                pattern: "{area:exists}/{controller=Account}/{action=SignIn}/{id?}");

            app.MapControllerRoute(
              name: "default",
              pattern: "{controller=Home}/{action=Index}/{id?}");




            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                await DBHelper.SetRoles(services);

            }
            app.Run();
        }
    }
}
