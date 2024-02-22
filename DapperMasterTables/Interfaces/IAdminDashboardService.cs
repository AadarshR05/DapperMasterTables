using DapperMasterTables.Models.APIModel;

namespace DapperMasterTables.Interfaces
{
    public interface IAdminDashboardService
    {
        Task<AdminDashboardCountAPIModel> GetDashboardCountsAsync();
    }
}
