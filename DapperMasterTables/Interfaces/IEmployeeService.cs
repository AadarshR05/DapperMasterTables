using DapperMasterTables.Models;

namespace DapperMasterTables.Interfaces
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employees>> GetEmployeesAsync();
        Task<Employees> GetEmployeesByIdAsync(int id);
        Task CreateEmployeesAsync(Employees employee);
        Task UpdateEmployeesAsync(int id, Employees employee);
        Task DeleteEmployeesAsync(int id);
    }
}
