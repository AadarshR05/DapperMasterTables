using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using Microsoft.AspNetCore.Mvc;

namespace DapperMasterTables.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _statusService;

        public StatusController(IStatusService statusService)
        {
            _statusService = statusService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var statuss = _statusService.GetStatus();
            return Ok(statuss);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var status = _statusService.GetStatusById(id);
            if (status == null) return NotFound();
            return Ok(status);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Status status)
        {
            _statusService.CreateStatus(status);
            return CreatedAtAction(nameof(GetById), new { id = status.StatusID }, status);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Status status)
        {
            _statusService.UpdateStatus(id, status);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _statusService.DeleteStatus(id);
            return NoContent();
        }
    }
}
