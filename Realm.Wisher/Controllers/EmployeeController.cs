using Microsoft.AspNetCore.Mvc;
using Realm.Wisher.Core.Entities;
using Realm.Wisher.Services.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Realm.Wisher.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<List<Employee>> GetEmployees()
        {
            return await _employeeService.GetEmployees();
        }

        [HttpGet("Excluded")]
        public async Task<List<int>> GetExcluded()
        {
            return await _employeeService.GetExcludedEmployeeIds();
        }
    }
}
