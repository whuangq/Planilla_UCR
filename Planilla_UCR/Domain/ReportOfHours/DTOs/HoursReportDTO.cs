using System;

namespace Domain.ReportOfHours.DTOs
{
    public class HoursReportDTO
    {
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String EmployeeEmail { get; set; }
        public DateTime ReportDate { get; set; }

        public HoursReportDTO(String employerEmail, String projectName, String employeeEmail,
            DateTime reportDate, int id, String bankAccount)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            EmployeeEmail = employeeEmail;
            ReportDate = reportDate;
        }
    }
}
