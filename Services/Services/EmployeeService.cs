using ConcernsClass.Concerns;
using Service.Services.Constants;
using Service.Services.Enums;
using Service.Services.Utilities;
using Service.Services.Interfaces;
using Repository.Repository.Interfaces;

namespace Service.Services
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployeeRepository _employeeRepository;
        private readonly IRolesRepository _rolesRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IRolesRepository rolesRepository)
        {
            _employeeRepository = employeeRepository;
            _rolesRepository = rolesRepository;
        }


        public void AddEmployee()
        {
            List<Employee> employeeData = _employeeRepository.LoadData();
            var emp = AddEmployeeData(employeeData);
            _employeeRepository.AddData(emp);
        }

        public void DeleteEmployee()
        {
            List<Employee> employeeData = _employeeRepository.LoadData();
            List<Employee> emp = DeleteEmployeeData(employeeData);
            _employeeRepository.SaveData(emp);
        }

        public void EditEmployee()
        {
            List<Employee> employeeData = _employeeRepository.LoadData();
            List<Employee> emp = EditEmployeeData(employeeData);
            _employeeRepository.SaveData(emp);
        }

        public void DisplayOne()
        {
            List<Employee> employeeData = _employeeRepository.LoadData();
            DisplayOneEmployee(employeeData);
        }

        public void DisplayAll()
        {
            List<Employee> employeeData = _employeeRepository.LoadData();
            DisplayAllEmployees(employeeData);
        }

        public Employee? AddEmployeeData(List<Employee> empData)
        {
            Employee emp = new Employee();
            emp.Id = Utils.ValidateEmpId();
            var isExists = false;

            if (empData != null)
            {
                foreach (Employee employee in empData)
                {
                    if (employee != null)
                    { 
                        if (employee.Id == emp.Id)
                        {
                            isExists = true;
                            Console.WriteLine(Constant.EmployeeExistswiththisID);
                            break;
                        }
                    }
                }
            }

            if (!isExists)
            {
                emp.FirstName = Utils.ValidateFirstName();
                emp.LastName = Utils.ValidateLastName();
                emp.Name = emp.LastName + " " + emp.FirstName;
                emp.Dob = Utils.ValidateDob();
                emp.EmailId = Utils.ValidateEmailId();
                emp.Mobile = Utils.ValidateMobile();
                emp.JoinDate = Utils.ValidateJoinDate();
                emp.Location = Utils.ValidateLocation(_rolesRepository.LoadData());
                emp.JobTitle = Utils.ValidateJobTitle(_rolesRepository.LoadData());
                emp.Department = Utils.ValidateDepartment(_rolesRepository.LoadData());
                emp.Manager = Utils.ValidateManager();
                emp.Project = Utils.ValidateProject();
                Console.WriteLine("\nEmployee added successfully\n");
                return emp;
            }
            else
            {
                return null;
            }
        }

        public void DisplayOneEmployee(List<Employee> employee)
        {
            Console.Write(Constant.EnterEmployeeID);
            var empNo = Console.ReadLine();
            var isExists = false;
            foreach (Employee emp in employee)
            {
                if (emp != null)
                {
                    if (emp.Id.Equals(empNo))
                    {
                        DisplayEmployeeHeaders();
                        DisplayEmployeeDetails(emp);
                        DashedLines();
                        isExists = true;
                    }
                }
            }
            if (!isExists)
            {
                Console.WriteLine(Constant.NoDataAvailable);
            }
        }

        public void DisplayAllEmployees(List<Employee> employee)
        {
            if (employee != null && employee.Count > 0)
            {
                DisplayEmployeeHeaders();
                foreach (Employee emp in employee)
                {
                    if (emp != null)
                        DisplayEmployeeDetails(emp);
                }
                DashedLines();
            }
            else
            {
                Console.WriteLine(Constant.NoDataAvailable);
            }
        }

        public List<Employee> DeleteEmployeeData(List<Employee> employee)
        {
            Console.Write(Constant.EnterEmployeeIdToDelete);
            var empId = Console.ReadLine();
            var isExists = false;
            var i = 0;
            var index = 0;
            foreach (Employee emp in employee)
            {
                if (emp != null)
                {
                    if (emp.Id.Equals(empId))
                    {
                        isExists = true;
                        index = i;

                        break;
                    }
                    i++;
                }
            }
            if (!isExists)
            {
                Console.WriteLine(Constant.EmployeeIdIsNotValid);
            }
            else
            {
                employee.RemoveAt(index);
                Console.WriteLine(Constant.EmployeeDeletedSuccessfully);
            }
            return employee;
        }

        public List<Employee> EditEmployeeData(List<Employee> employee)
        {
            Console.Write(Constant.EnterEmployeeIdToEdit);
            var empId = Console.ReadLine();
            var isExists = false;
            List<Employee> employeeList = new List<Employee>();
            foreach (Employee emp in employee)
            {
                if (emp != null)
                {
                    if (emp.Id.Equals(empId))
                    {
                        isExists = true;
                        ModifyEmployee(emp);
                    }
                    employeeList.Add(emp);
                }
            }
            if (!isExists)
            {
                Console.WriteLine(Constant.EmployeeIdIsNotValid);
            }
            return employeeList;
        }

        public void EmployeeManagement()
        {
            var isBack = false;
            while (!isBack)
            {
                PrintEmployeeOptions();
                Console.Write(Constant.ChooseYourChoice);
                var input = Console.ReadLine();
                int value;
                if (int.TryParse(input, out value))
                {
                    EmployeeOptionsEnum choice = (EmployeeOptionsEnum)value;
                    Console.WriteLine();
                    switch (choice)
                    {
                        case EmployeeOptionsEnum.Add:
                            AddEmployee();
                            break;

                        case EmployeeOptionsEnum.Delete:
                            DeleteEmployee();
                            break;

                        case EmployeeOptionsEnum.Edit:
                            EditEmployee();
                            break;

                        case EmployeeOptionsEnum.DisplayOne:
                            DisplayOne();
                            break;

                        case EmployeeOptionsEnum.DisplayAll:
                            DisplayAll();
                            break;
                        case EmployeeOptionsEnum.MainMenu:
                            isBack = true;
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

        #region helpers
        private static void PrintEmployeeOptions()
        {
            Console.WriteLine("\n1.Add Employee\n2.Delete Employee\n3.Edit Employee\n4.DisplayOneEmployee\n5.DisplayAllEmployee\n6.Back\n");
        }

        private static void PrintEditOptions()
        {
            Console.Write("\n1.Name\n2.Date Of Birth\n3.Email Id\n4.Mobile\n5.Joining Date\n6.Location\n7.Role\n8.Department\n9.Manager\n10.Project\n11.Back\n");
        }

        private void DisplayEmployeeHeaders()
        {
            DashedLines();
            Console.WriteLine("|{0,-13} | {1,-15} | {2,-22} | {3,-19} | {4,-18} | {5,-18} | {6,-18} | {7,-18} |",
            "EmpNo", "Name", "Role", "Department", "Location", "Join Date", "Manager", "Project");
        }

        private void DisplayEmployeeDetails(Employee emp)
        {
            DashedLines();
            Console.WriteLine("|{0,-13} | {1,-15} | {2,-22} | {3,-19} | {4,-18} | {5,-18} | {6,-18} | {7,-18} |",
                emp.Id, emp.Name, emp.JobTitle, emp.Department, emp.Location, emp.JoinDate.ToShortDateString(), emp.Manager, emp.Project);
        }

        private void DashedLines()
        {
            for (int i = 0; i < 164; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine();
        }

        private void ModifyEmployee(Employee emp)
        {
            PrintEditOptions();
            Console.Write(Constant.ChooseYourChoice);
            var input = Console.ReadLine();
            int value;
            var isFail = false;
            if (int.TryParse(input, out value))
            {
                EmployeeEditOptionsEnum choice = (EmployeeEditOptionsEnum)value;
                switch (choice)
                {
                    case EmployeeEditOptionsEnum.Name:
                        Console.Write(Constant.EnterFirstName);
                        emp.FirstName = Console.ReadLine();
                        Console.Write(Constant.EnterLastName);
                        emp.LastName = Console.ReadLine();
                        emp.Name = emp.LastName + " " + emp.FirstName;
                        break;
                    case EmployeeEditOptionsEnum.Dob:
                        Console.Write(Constant.EnterDob);
                        try
                        {
                            emp.Dob = Convert.ToDateTime(Console.ReadLine());
                        }
                        catch
                        {
                            isFail = true;
                            Console.WriteLine("Invalid Date Format");
                        }
                        break;
                    case EmployeeEditOptionsEnum.Email:
                        Console.Write(Constant.EnterEmailId);
                        emp.EmailId = Console.ReadLine();
                        break;
                    case EmployeeEditOptionsEnum.Mobile:
                        Console.Write(Constant.EnterMobile);
                        emp.Mobile = Console.ReadLine();
                        break;
                    case EmployeeEditOptionsEnum.JoinDate:
                        Console.Write(Constant.EnterJoinDate);
                        emp.JoinDate = Convert.ToDateTime(Console.ReadLine());
                        break;
                    case EmployeeEditOptionsEnum.Location:
                        emp.Location = Utils.ValidateLocation(_rolesRepository.LoadData());
                        break;
                    case EmployeeEditOptionsEnum.Role:
                        emp.JobTitle = Utils.ValidateJobTitle(_rolesRepository.LoadData());
                        break;
                    case EmployeeEditOptionsEnum.Department:
                        emp.Department = Utils.ValidateDepartment(_rolesRepository.LoadData());
                        break;
                    case EmployeeEditOptionsEnum.Manager:
                        Console.Write(Constant.EnterManager);
                        emp.Manager = Console.ReadLine();
                        break;
                    case EmployeeEditOptionsEnum.Project:
                        emp.Project = Utils.ValidateProject();
                        break;
                    case EmployeeEditOptionsEnum.Back:
                        break;
                    default:
                        Console.WriteLine(Constant.AvailableOptions);
                        break;
                }
            }
            if (!isFail) Console.WriteLine("Employee Updated Successfully");

        }

        #endregion
    }
}
