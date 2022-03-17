using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Realm.Wisher.Core.Entities;
using Realm.Wisher.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Realm.Wisher.Worker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IEmployeeService _employeeService;
        private readonly IEmailSender _emailSender;

        public Worker(
            IEmployeeService employeeService,
            IEmailSender emailSender,
            ILogger<Worker> logger)
        {
            _logger = logger;
            _employeeService = employeeService;
            _emailSender = emailSender;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var employees = await _employeeService.GetEmployees();
                var birthdays = employees.Where(e => e.DateOfBirth.Month == DateTime.Now.Month && e.DateOfBirth.Day == DateTime.Now.Day).ToList();

                var excludedIds = await _employeeService.GetExcludedEmployeeIds();

                // Check do not send 
                birthdays = birthdays.Where(e => !excludedIds.Contains(e.Id)).ToList();

                // Check if they are still employeed with us
                birthdays = birthdays.Where(e => e.EmploymentEndDate == null || e.EmploymentEndDate.Value.CompareTo(DateTime.Now) >= 0).ToList();

                // Check if they have started working with us
                birthdays = birthdays.Where(e => e.EmploymentStartDate.CompareTo(DateTime.Now) <= 0).ToList();

                // Check if we have send a notification before
                birthdays = birthdays.Where(e => e.LastNotification == null || DateTime.Now.CompareTo(e.LastNotification.Value) > 366).ToList();

                if (birthdays.Any())
                {
                    await _emailSender.SendEmail($"Happy Birthday {string.Join(", ", birthdays.Select(b => b.Name).ToList())}");
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
