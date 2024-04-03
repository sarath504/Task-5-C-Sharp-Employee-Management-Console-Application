using ConcernsClass.Concerns;

namespace Repository.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        public List<Employee> LoadData();

        public void AddData(Employee emp);

        public void SaveData(List<Employee> emp);

    }
}
