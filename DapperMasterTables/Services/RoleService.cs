using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using System.Data;
using System.Linq;
using Microsoft.Data.SqlClient;
using Dapper;
using Microsoft.Extensions.Configuration; // Make sure to add this using directive

namespace DapperMasterTables.Services
{
    public class RoleService : IRoleService
    {
        private readonly IDbConnection _db;

        public RoleService(IConfiguration configuration) // Inject IConfiguration
        {
            // Retrieve the connection string from appsettings.json
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _db = new SqlConnection(connectionString);
        }

        public IEnumerable<Role> GetRoles()
        {
            return _db.Query<Role>("spRoleCRUD", new { Action = "SELECT" }, commandType: CommandType.StoredProcedure);
        }

        public Role GetRoleById(int id)
        {
            return _db.Query<Role>("spRoleCRUD", new { Action = "SELECT", RoleID = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }

        public void CreateRole(Role role)
        {
            _db.Execute("spRoleCRUD", new { Action = "INSERT", RoleName = role.RoleName }, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(int id, Role role)
        {
            _db.Execute("spRoleCRUD", new { Action = "UPDATE", RoleID = id, RoleName = role.RoleName }, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            _db.Execute("spRoleCRUD", new { Action = "DELETE", RoleID = id }, commandType: CommandType.StoredProcedure);
        }
    }
}
