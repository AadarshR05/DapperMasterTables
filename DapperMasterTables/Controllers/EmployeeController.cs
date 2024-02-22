using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DapperMasterTables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService; // Renamed from _roleService for clarity

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.GetEmployeesAsync();
            return Ok(employees);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var employee = await _employeeService.GetEmployeesByIdAsync(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Employees employee)
        {
            await _employeeService.CreateEmployeesAsync(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.EmployeeID }, employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Employees employee)
        {
            await _employeeService.UpdateEmployeesAsync(id, employee);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _employeeService.DeleteEmployeesAsync(id);
            return NoContent();
        }
    }
}
