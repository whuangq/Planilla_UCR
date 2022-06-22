using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using Domain.ReportOfHours.Repositories;

namespace Application.ReportOfHours.Implementations
{
    internal class ReportOfHoursService : IReportOfHoursService
    {
        private readonly IHoursReportRepository _reportRepository;

        public ReportOfHoursService(IHoursReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            await _reportRepository.CreateReportAsync(report);
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            return await _reportRepository.GetAllReportsAsync(email);
        }

        public Task<bool> HasReportAsync(HoursReport report)
        {
            return _reportRepository.HasReportAsync(report);
        }

        public Task<IList<HoursReport>> GetEmployeeReports(HoursReport hoursReport, DateTime endDate) 
        { 
            return _reportRepository.GetEmployeeReports(hoursReport, endDate);
        }
    }
}
