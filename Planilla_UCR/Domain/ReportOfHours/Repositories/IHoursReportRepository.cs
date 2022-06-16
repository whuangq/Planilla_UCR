using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;

namespace Domain.ReportOfHours.Repositories
{
    public interface IHoursReportRepository
    {
        Task CreateReportAsync(HoursReport report);
        Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email);
        Task<bool> HasReportAsync(HoursReport report);
    }
}
