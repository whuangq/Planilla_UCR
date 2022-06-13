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
    }
}
