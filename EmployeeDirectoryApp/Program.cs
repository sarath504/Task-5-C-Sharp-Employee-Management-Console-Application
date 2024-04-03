using Microsoft.Extensions.DependencyInjection;
using Repository.Repository;
using Service.Services;
using Service.Services.Interfaces;
using Repository.Repository.Interfaces;

namespace EmployeeDirectoryApp
{
    class Program
    {
        public static void Main(string[] args)
        {
            var services = new ServiceCollection();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IEmployeeManagementMenu, EmployeeManagementMenu>();
            services.AddTransient<IRolesService, RolesService>();
            services.AddTransient<IRolesRepository, RolesRepository>();

            var serviceProvider = services.BuildServiceProvider();
            var service = serviceProvider.GetRequiredService<IEmployeeManagementMenu>();
            service.EmployeeDirectory();
        }
    }
}
