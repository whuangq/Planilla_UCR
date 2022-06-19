using Domain.Core.Repositories;
using Domain.ReportOfHours.Repositories;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.ReportOfHours.Repositories
{
    internal class HoursReportRepository : IHoursReportRepository
    {
        private readonly HoursReportDbContext _dbContext;
        public IUnitOfWork UnitOfWork => _dbContext;

        public HoursReportRepository(HoursReportDbContext unitOfWork)
        {
            _dbContext = unitOfWork;
        }

        public async Task CreateReportAsync(HoursReport report)
        {
            _dbContext.HoursReport.Add(report);
            await _dbContext.SaveEntitiesAsync();
        }

        public async Task<bool> HasReportAsync(HoursReport report)
        {
            bool hasReport = true;
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == report.EmployeeEmail && e.EmployerEmail == 
                     report.EmployerEmail && e.ReportDate.Value.Date == report.ReportDate.Value.Date && 
                     e.ProjectName == report.ProjectName).ToListAsync();
            if(reports.Length() == 0)
            {
                hasReport = false;
            }
            return hasReport;
        }

        public async Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email)
        {
            IEnumerable<HoursReport> reports = await _dbContext.HoursReport.Where
               (e => e.EmployeeEmail == email).ToListAsync();
            return reports;
        }
    }
}
