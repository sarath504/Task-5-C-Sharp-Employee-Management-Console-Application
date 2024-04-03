using Service.Services.Constants;
using Service.Services.Enums;
using Service.Services.Interfaces;

namespace Service.Services
{

    public class EmployeeManagementMenu : IEmployeeManagementMenu
    {
        private readonly IEmployeeService _employeeService;
        private readonly IRolesService _rolesService;
        public EmployeeManagementMenu(IEmployeeService employeeService, IRolesService rolesService)
        {
            _employeeService = employeeService;
            _rolesService = rolesService;
        }
        public void EmployeeDirectory()
        {
            while (true)
            {
                Console.WriteLine(Constant.EmployeeDirectoryOptions);
                Console.Write(Constant.ChooseYourChoice);
                var input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    EmployeeDirectoryOptionsEnum choice = (EmployeeDirectoryOptionsEnum)value;
                    Console.WriteLine();
                    switch (choice)
                    {
                        case EmployeeDirectoryOptionsEnum.Employee:
                            _employeeService.EmployeeManagement();
                            break;
                        case EmployeeDirectoryOptionsEnum.Role:
                            _rolesService.RoleManagement();
                            break;
                        case EmployeeDirectoryOptionsEnum.Exit:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine(Constant.AvailableOptions);
                            break;
                    }
                }
                else
                {
                    Console.WriteLine(Constant.AvailableOptions);
                }
            }

        }
    }
}
