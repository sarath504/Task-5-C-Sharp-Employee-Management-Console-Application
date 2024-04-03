using ConcernsClass.Concerns;
using Service.Services.Constants;
using System.Text.RegularExpressions;
using Repository.Repository.Interfaces;

namespace Service.Services.Utilities
{
    class Utils
    {
        private readonly IRolesRepository _rolesRepository;
        public Utils(IRolesRepository rolesRepository)
        {
            _rolesRepository = rolesRepository;
        }
        public static string ValidateEmpId()
        {
            Console.Write(Constant.EnterEmployeeNumber);
            var empNo = Console.ReadLine();
            var empReg = new Regex(@"^TZ\d{4}$");
            while (!empReg.IsMatch(empNo))
            {
                Console.WriteLine(Constant.EmployeeIdIsNotValid);
                Console.Write(Constant.EnterEmployeeNumber);
                empNo = Console.ReadLine();
            }
            return empNo;
        }

        public static string ValidateFirstName()
        {
            Console.Write(Constant.EnterFirstName);
            var name = Console.ReadLine();
            var nameReg = new Regex(@"^[A-Za-z\s]+$");
            while (!nameReg.IsMatch(name))
            {
                Console.WriteLine(Constant.FirstNameNotValid);
                Console.Write(Constant.EnterFirstName);
                name = Console.ReadLine();
            }
            return name;
        }

        public static string ValidateLastName()
        {
            Console.Write(Constant.EnterLastName);
            var name = Console.ReadLine();
            var nameReg = new Regex(@"^[A-Za-z\s]+$");
            while (!nameReg.IsMatch(name))
            {
                Console.WriteLine(Constant.LastNameNotValid);
                Console.Write(Constant.EnterLastName);
                name = Console.ReadLine();
            }
            return name;
        }

        public static DateTime ValidateDob()
        {
            Console.Write(Constant.EnterDob);
            var dob = Console.ReadLine();
            var dateReg = new Regex(@"^(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])/(\d{4})$");
            while (!dateReg.IsMatch(dob))
            {
                Console.WriteLine(Constant.DobNotValid);
                Console.Write(Constant.EnterDob);
                dob = Console.ReadLine();
            }
            var date = Convert.ToDateTime(dob);
            return date;
        }

        public static DateTime ValidateJoinDate()
        {
            Console.Write(Constant.EnterJoinDate);
            var joinDt = Console.ReadLine();
            var dateReg = new Regex(@"^(0[1-9]|1[0-2])/(0[1-9]|[1-2][0-9]|3[0-1])/(\d{4})$");
            while (!dateReg.IsMatch(joinDt))
            {
                Console.WriteLine(Constant.JoinDateNotValid);
                Console.Write(Constant.EnterJoinDate);
                joinDt = Console.ReadLine();
            }
            var joinDate = Convert.ToDateTime(joinDt);
            return joinDate;
        }

        public static string ValidateEmailId()
        {
            Console.Write(Constant.EnterEmailId);
            var email = Console.ReadLine();
            var emailReg = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,4}$\r\n");
            while (emailReg.IsMatch(email))
            {
                Console.WriteLine(Constant.EmailIdNotValid);
                Console.Write(Constant.EnterEmailId);
                email = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(email))
            {
                Console.WriteLine(Constant.EmailIdNotValid);
                Console.Write(Constant.EnterEmailId);
                email = Console.ReadLine();
            }
            return email;
        }

        public static string ValidateMobile()
        {
            Console.Write(Constant.EnterMobile);
            var mobile = Console.ReadLine();
            var mob = new Regex(@"^[0-9]{10}$");
            while (!mob.IsMatch(mobile))
            {
                Console.WriteLine(Constant.MobileNumberNotValid);
                Console.Write(Constant.EnterMobile);
                mobile = Console.ReadLine();
            }
            return mobile;
        }

        public static string ValidateLocation(List<Role> roleData)
        {
            List<string> list = new List<string>();
            if (roleData != null)
            {
                foreach (Role role in roleData)
                {
                    if (role != null && !list.Contains(role.Location))
                        list.Add(role.Location);
                }
            }
            Console.WriteLine(Constant.EnterLocation);
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write("\n" + (i + 1) + "." + list[i]);
            }
            Console.WriteLine();
            Console.Write(Constant.ChooseYourChoice);
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice > list.Count)
                return list[0];
            else
                return list[choice - 1];
           
        }

        public static string ValidateRoleLocation()
        {
            Console.Write(Constant.EnterLocation);
            var location = Console.ReadLine();
            var nameReg = new Regex(@"^[A-Za-z\s]+$");
            while (!nameReg.IsMatch(location))
            {
                Console.WriteLine(Constant.LocationNotValid);
                Console.Write(Constant.EnterLocation);
                location = Console.ReadLine();
            }
            return location;
        }

        public static string ValidateRoleDepartment()
        {
            string[] deptList = { "Product Engineer", "QA", "Finance", "System Analyst" };
            var department = Constant.Department;
            Console.Write(Constant.DepartmentList);
            Console.Write(Constant.ChooseDepartment);
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 4)
            {
                return deptList[choice - 1];
            }
            else
            {
                return department;
            }
        }

        public static string ValidateDepartment(List<Role> roleData)
        {
            List<string> list = new List<string>();
            if (roleData != null)
            {
                foreach (Role role in roleData)
                {
                    if (role != null && !list.Contains(role.Department))
                        list.Add(role.Department);
                }
            }
            Console.WriteLine(Constant.EnterDepartment);
            for (var i = 0; i < list.Count; i++)
            {
                Console.Write("\n" + (i + 1) + "." + list[i]);
            }
            Console.WriteLine();
            Console.Write(Constant.ChooseYourChoice);
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice > list.Count)
                return list[0];
            else
                return list[choice - 1];
        }

        public static string ValidateJobTitle(List<Role> roleData)
        {
            List<string> list = new List<string>();
            if (roleData != null)
            {
                foreach (Role role in roleData)
                {
                    if(role!=null)
                        list.Add(role.Name);
                }
            }
            Console.WriteLine(Constant.EnterRole);
            for(var i = 0; i < list.Count; i++)
            {
                Console.Write("\n" + (i + 1) + "." + list[i]);
            }
            Console.WriteLine();
            Console.Write(Constant.ChooseYourChoice);
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice > list.Count)
                return list[0];
            else
                return list[choice - 1];
        }

        public static string ValidateManager()
        {
            Console.Write(Constant.EnterManager);
            var manager = Console.ReadLine();
            if (string.IsNullOrEmpty(manager))
            {
                manager = "-";
            }
            return manager;
        }

        public static string ValidateProject()
        {
            string[] projectList = { "Project-A", "Project-B", "Project-C" };
            var project = Constant.DefaultProject;
            Console.Write(Constant.ProjectList);
            Console.Write(Constant.EnterProject);
            var choice = Convert.ToInt32(Console.ReadLine());
            if (choice < 4)
            {
                return projectList[choice - 1];
            }
            else
            {
                return project;
            }
        }

        public static string ValidateRoleName()
        {
            Console.Write(Constant.EnterRole);
            var roleName = Console.ReadLine();
            var regExp = new Regex(@"^[A-Za-z\s]+$");
            while (!regExp.IsMatch(roleName))
            {
                Console.WriteLine(Constant.RoleNotValid);
                Console.Write(Constant.EnterRole);
                roleName = Console.ReadLine();
            }
            while (string.IsNullOrEmpty(roleName))
            {
                Console.WriteLine(Constant.RoleNotValid);
                Console.Write(Constant.EnterRole);
                roleName = Console.ReadLine();
            }
            return roleName;
        }

        public static string ValidateDescription()
        {
            Console.Write(Constant.RoleDescription);
            var roleDescription = Console.ReadLine();
            if (string.IsNullOrEmpty(roleDescription))
            {
                roleDescription = Constant.DefaultRoleDescription;
            }
            return roleDescription;
        }
    }
}
