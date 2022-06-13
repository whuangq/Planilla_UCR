using System;

namespace Domain.ReportOfHours.Entities
{
    public class HoursReport
    {
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String EmployeeEmail { get; set; }
        public DateTime? ReportDate { get; set; }
        public float ReportHours { get; set; }

        public HoursReport(String employerEmail, String projectName, String employeeEmail,
            DateTime? reportDate, float reportedHours)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            EmployeeEmail = employeeEmail;
            ReportDate = reportDate;
            ReportHours = reportedHours;
        }

        public HoursReport()
        {
        }
    }
}
