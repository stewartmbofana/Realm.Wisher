using System.Collections.Generic;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Realm.Wisher.Core.Entities;
using Realm.Wisher.Services.Interfaces;

namespace Realm.Wisher.Services.Business
{
    public class EmployeeService : IEmployeeService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://interview-assessment-1.realmdigital.co.za")
        };
        private readonly ILogger<EmployeeService> _logger;

        public EmployeeService(ILogger<EmployeeService> logger)
        {
            _logger = logger;
        }

        public async Task<List<Employee>> GetEmployees()
        {
            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var streamTask = client.GetStreamAsync("/employees");

                return await JsonSerializer.DeserializeAsync<List<Employee>>(await streamTask);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                throw;
            }
        }

        public async Task<List<int>> GetExcludedEmployeeIds()
        {

            try
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

                var streamTask = client.GetStreamAsync("/do-not-send-birthday-wishes");

                return await JsonSerializer.DeserializeAsync<List<int>>(await streamTask);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);

                throw;
            }
        }
    }
}
