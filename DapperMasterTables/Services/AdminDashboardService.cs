using Dapper;
using System.Data.SqlClient;
using System.Threading.Tasks;
using DapperMasterTables.Interfaces;
using DapperMasterTables.Models.APIModel;
using Microsoft.Data.SqlClient;

public class AdminDashboardService : IAdminDashboardService
{
    private readonly IConfiguration _configuration;

    public AdminDashboardService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public async Task<AdminDashboardCountAPIModel> GetDashboardCountsAsync()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        using var connection = new SqlConnection(connectionString);

        var model = new AdminDashboardCountAPIModel();

        // Assuming you have a stored procedure or direct SQL queries to fetch counts
        model.MenteeCount = await connection.ExecuteScalarAsync<int>("SELECT dbo.GetDashboardCount('Mentee','active')");
        model.MentorCount = await connection.ExecuteScalarAsync<int>("SELECT dbo.GetDashboardCount('Mentor','active')");
        model.ActivePairCount = await connection.ExecuteScalarAsync<int>("SELECT dbo.GetDashboardCount(NULL,'active')"); // Assuming NULL fetches active pairs
        model.TotalEmployees = await connection.ExecuteScalarAsync<int>("SELECT dbo.GetDashboardCount('TOTAL_EMP','active')");

        return model;
    }
}
