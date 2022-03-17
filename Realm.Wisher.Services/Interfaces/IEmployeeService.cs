using Realm.Wisher.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realm.Wisher.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<List<Employee>> GetEmployees();
        Task<List<int>> GetExcludedEmployeeIds();
    }
}
