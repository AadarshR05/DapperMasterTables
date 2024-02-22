using System.ComponentModel.DataAnnotations;

namespace DapperMasterTables.Models
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }

        public string RoleName { get; set; }
    }
}
