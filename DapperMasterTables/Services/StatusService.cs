using Dapper;
using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Net.NetworkInformation;

namespace DapperMasterTables.Services
{
    public class StatusService : IStatusService
    {
        private readonly IDbConnection _connection;
        public StatusService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _connection = new SqlConnection(connectionString);
        }
        public IEnumerable<Status> GetStatus()
        {
            return _connection.Query<Status>("spStatusCRUD", new { Action = "GET" },commandType: CommandType.StoredProcedure);
        }
        public Status GetStatusById(int id)
        {
            return _connection.Query<Status>("spStatusCRUD", new { Action = "GET", StatusID = id }, commandType: CommandType.StoredProcedure).FirstOrDefault();
        }
        public void CreateStatus(Status status)
        {
            _connection.Query<Status>("spStatusCRUD", new { Action = "POST", StatusValue = status.StatusValue },commandType: CommandType.StoredProcedure);
        }
        
        public void UpdateStatus(int id, Status status)
        {
            _connection.Query<Status>("spStatusCRUD", new { Action = "UPDATE", StatusID = status.StatusID, StatusValue = status.StatusValue },commandType: CommandType.StoredProcedure);
        }
        public void DeleteStatus(int id)
        {
            _connection.Query<Status>("spStatusCRUD", new { Action = "DELETE", StatusID = id },commandType: CommandType.StoredProcedure);
        }
    }
}
