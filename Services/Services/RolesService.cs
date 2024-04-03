using ConcernsClass.Concerns;
using Service.Services.Enums;
using Service.Services.Constants;
using Service.Services.Utilities;
using Service.Services.Interfaces;
using Repository.Repository.Interfaces;

namespace Service.Services
{
    public class RolesService:IRolesService
    {
        Role role = new Role();

        private readonly IRolesRepository _rolesRepository;
        public RolesService(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }

        public void AddRole()
        {
            var role = AddRoleData();
            _rolesRepository.AddRole(role);
        }
        public Role AddRoleData()
        {
            role.Name = Utils.ValidateRoleName();
            role.Department = Utils.ValidateRoleDepartment();
            role.Description = Utils.ValidateDescription();
            role.Location = Utils.ValidateRoleLocation();
            Console.WriteLine(Constant.RoleAdded);
            return role;
        }

        public void DisplayRole()
        {
            List<Role> roles = _rolesRepository.LoadData();
            DisplayAllRoles(roles);
        }

        public void DisplayAllRoles(List<Role> rolesList)
        {
            DashedLines();
            RolesTableHeader();
            foreach (var role in rolesList)
            {
                DashedLines();
                Console.WriteLine("| {0,-25} | {1,-25} | {2,-25} | {3,-25} |",
                    role.Name, role.Department, role.Description, role.Location);
            }
            DashedLines();
        }

        public void RoleManagement()
        {
            var isBack = false;
            while (!isBack)
            {
                Console.WriteLine(Constant.RoleOptions);
                Console.Write(Constant.ChooseYourChoice);
                var input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    RoleOptionsEnum choice = (RoleOptionsEnum)value;
                    Console.WriteLine();
                    switch (choice)
                    {
                        case RoleOptionsEnum.Add:
                            AddRole();
                            break;
                        case RoleOptionsEnum.Display:
                            DisplayRole();
                            break;
                        case RoleOptionsEnum.Back:
                            isBack = true;
                            break;
                        default:
                            Console.WriteLine(Constant.AvailableOptions);
                            break;
                    }
                }
            }
        }
        #region helper
        private void DashedLines()
        {
            for (int i = 0; i < 112; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private void RolesTableHeader()
        {
            Console.WriteLine("| {0,-25} | {1,-25} | {2,-25} | {3,-25} |",
                    "Role", "Department", "Description", "Location");
        }
        #endregion
    }
}
