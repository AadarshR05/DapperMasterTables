using System.ComponentModel.DataAnnotations;

namespace DapperMasterTables.Models
{
    public class Status
    {
        [Key]
        public int StatusID { get; set; }

        public string StatusValue { get; set; }
    }
}
