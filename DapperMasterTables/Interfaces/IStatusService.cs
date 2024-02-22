using DapperMasterTables.Models;

namespace DapperMasterTables.Interfaces
{
    public interface IStatusService
    {
        IEnumerable<Status> GetStatus();
        Status GetStatusById(int id);
        void CreateStatus(Status status);
        void UpdateStatus(int id, Status status);
        void DeleteStatus(int id);
    }
}
