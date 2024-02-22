using System.ComponentModel.DataAnnotations;

namespace DapperMasterTables.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeID { get; set; }

        public string OutlookEmployeeID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmailId { get; set; }

        public DateTime CreatedDate { get; set; }

        public string AccountStatus { get; set; }
    }
}
