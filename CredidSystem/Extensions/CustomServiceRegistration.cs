using CredidSystem.Service;
using CredidSystem.Service.Implementation;
using CredidSystem.Service.Interface;

namespace CredidSystem.Extensions
{
    public static class CustomServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericService<,>), typeof(GenericService<,>));

            services.AddScoped<IMerchantService, MerchantService>();
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<EmailService>();



        }
    }
}
