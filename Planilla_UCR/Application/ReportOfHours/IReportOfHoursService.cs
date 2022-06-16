using Domain.ReportOfHours.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.ReportOfHours
{
    public interface IReportOfHoursService
    {
        Task CreateReportAsync(HoursReport report);
        Task<IEnumerable<HoursReport>> GetAllReportsAsync(string email);
        Task<bool> HasReportAsync(HoursReport report);
    }
}
