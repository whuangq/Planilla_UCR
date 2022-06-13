using System.Threading.Tasks;
using Domain.ReportOfHours.Entities;

namespace Domain.ReportOfHours.Repositories
{
    public interface IHoursReportRepository
    {
        Task CreateReportAsync(HoursReport report);
    }
}
