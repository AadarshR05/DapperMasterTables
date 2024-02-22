using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperMasterTables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var roles = _roleService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var role = _roleService.GetRoleById(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Role role)
        {
            _roleService.CreateRole(role);
            return CreatedAtAction(nameof(GetById), new { id = role.RoleID }, role);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Role role)
        {
            _roleService.UpdateRole(id, role);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _roleService.DeleteRole(id);
            return NoContent();
        }
    }
}
