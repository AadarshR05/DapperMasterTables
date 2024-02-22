using DapperMasterTables.Models;

namespace DapperMasterTables.Interfaces
{
    public interface IRoleService
    {
        IEnumerable<Role> GetRoles();
        Role GetRoleById(int id);
        void CreateRole(Role role);
        void UpdateRole(int id, Role role);
        void DeleteRole(int id);
    }
}
