using Domain.ReportOfHours.Entities;
using System.Threading.Tasks;

namespace Application.ReportOfHours
{
    public interface IReportOfHoursService
    {
        Task CreateReportAsync(HoursReport report);
    }
}
