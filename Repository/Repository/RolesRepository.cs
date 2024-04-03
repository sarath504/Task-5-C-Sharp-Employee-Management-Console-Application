using ConcernsClass.Concerns;
using Newtonsoft.Json;
using Repository.Repository.Interfaces;

namespace Repository.Repository
{
    
    public class RolesRepository: IRolesRepository
    {
        public List<Role> LoadData()
        {
            var rolesList = JsonDeserialize();
            return rolesList;
        }

        public void AddRole(Role role)
        {
            var rolesList = JsonDeserialize();
            rolesList.Add(role);
            JsonSerialize(rolesList);
        }
        
        #region Helpers
        private void JsonSerialize(List<Role> list)
        {
            string json = JsonConvert.SerializeObject(list);
            File.WriteAllText("RolesDetails.json", json);
        } 

        private List<Role> JsonDeserialize()
        {
            List<Role> roles = JsonConvert.DeserializeObject<List<Role>>(File.ReadAllText(@"./RolesDetails.json"));
            return roles;
        }
        #endregion
    }
}
