using CredidSystem.Repository.Implementation;
using CredidSystem.Repository.Interface;

namespace CredidSystem.Extensions
{
    public static class CustomRepositoryRegistration
    {
       public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            //services.AddScoped<ILoanRepository, LoanRepository>();
            //services.AddScoped<ICustomerRepository, CustomerRepository>();
            //services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        }
    }
}
