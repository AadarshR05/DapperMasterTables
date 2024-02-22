using Dapper;
using DapperMasterTables.Interfaces;
using DapperMasterTables.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace DapperMasterTables.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbConnection _db;
        public EmployeeService(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");
            _db = new SqlConnection(connectionString);
        }

        public async Task<IEnumerable<Employees>> GetEmployeesAsync()
        {
            try
            {
                return await _db.QueryAsync<Employees>("spEmployeeCRUD", new { Action = "SELECT" }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log exception (Consider using a logging library)
                throw new Exception("An error occurred when getting employees", ex);
            }
        }

        public async Task<Employees> GetEmployeesByIdAsync(int id)
        {
            try
            {
                return (await _db.QueryAsync<Employees>("spEmployeeCRUD", new { Action = "SELECT", EmployeeID = id }, commandType: CommandType.StoredProcedure)).FirstOrDefault();
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred when getting employee by ID: {id}", ex);
            }
        }

        public async Task CreateEmployeesAsync(Employees employee)
        {
            try
            {
                await _db.ExecuteAsync("spEmployeeCRUD", new { Action = "INSERT", OutlookEmployeeID = employee.OutlookEmployeeID, FirstName = employee.FirstName, LastName = employee.LastName, EmailId = employee.EmailId, CreatedDate = employee.CreatedDate, AccountStatus = employee.AccountStatus }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception("An error occurred when creating an employee", ex);
            }
        }

        public async Task UpdateEmployeesAsync(int id, Employees employee)
        {
            try
            {
                await _db.ExecuteAsync("spEmployeeCRUD", new { Action = "Update", EmployeeID = id, OutlookEmployeeID = employee.OutlookEmployeeID, FirstName = employee.FirstName, LastName = employee.LastName, EmailId = employee.EmailId, CreatedDate = employee.CreatedDate, AccountStatus = employee.AccountStatus }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred when updating employee ID: {id}", ex);
            }
        }

        public async Task DeleteEmployeesAsync(int id)
        {
            try
            {
                await _db.ExecuteAsync("spEmployeeCRUD", new { Action = "DELETE", EmployeeID = id }, commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                // Log exception
                throw new Exception($"An error occurred when deleting employee ID: {id}", ex);
            }
        }
    }
}
