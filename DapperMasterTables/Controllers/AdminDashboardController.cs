using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DapperMasterTables.Interfaces;
using DapperMasterTables.Models.APIModel;

[Route("api/[controller]")]
[ApiController]
public class AdminDashboardController : ControllerBase
{
    private readonly IAdminDashboardService _dashboardService;

    public AdminDashboardController(IAdminDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    [HttpGet("dashboard-counts")]
    public async Task<ActionResult<AdminDashboardCountAPIModel>> GetDashboardCounts()
    {
        try
        {
            var counts = await _dashboardService.GetDashboardCountsAsync();
            return Ok(counts);
        }
        catch (Exception ex)
        {
            // Log the exception
            return StatusCode(500, "Internal server error: " + ex.Message);
        }
    }
}

