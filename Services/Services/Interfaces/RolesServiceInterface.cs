using ConcernsClass.Concerns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services.Interfaces
{
    public interface IRolesService
    {
        public void AddRole();
        public Role AddRoleData();
        public void DisplayRole();
        public void DisplayAllRoles(List<Role> rolesList);
        public void RoleManagement();
    }
}
