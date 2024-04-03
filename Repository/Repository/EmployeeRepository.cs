using ConcernsClass.Concerns;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    public class EmployeeRepository:IEmployeeRepository
    {
        public List<Employee> LoadData()
        {
            var employeesList = JsonDeserialize();
            return employeesList;
        }

        public void AddData(Employee emp)
        {
            var employeesList = JsonDeserialize();
            employeesList.Add(emp);
            JsonSerialize(employeesList);
        }

        public void SaveData(List<Employee> emp)
        {
            JsonSerialize(emp);
        }

        #region Helpers
        private void JsonSerialize(List<Employee> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("EmployeeDetails.json", json);
        }

        private List<Employee> JsonDeserialize()
        {
            var file = File.ReadAllText(@"./EmployeeDetails.json");
            var employees = JsonConvert.DeserializeObject<List<Employee>>(file, new IsoDateTimeConverter { DateTimeFormat = "MM/DD/YYYY" });
            return employees;
        }
        #endregion
    }
}
