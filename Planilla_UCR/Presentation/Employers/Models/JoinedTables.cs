using System;

namespace Presentation.Agreements.Models
{
    internal class JoinedTables
    {

        public string PaymentInterval { get; set; }
        public string EmployeeEmail { get; set; }
        public string ContractType { get; set; }
        public DateTime ContractStartDate { get; set; }
        public DateTime ContractFinishDate { get; set; }
        public int MountPerHour { get; set; }
        public string Name { get; set; }
        public string LastName1 { get; set; }
        public string LastName2 { get; set; }
        public JoinedTables()
        {
            this.PaymentInterval = "";
            this.EmployeeEmail = "";
            this.ContractType = "";
            this.ContractStartDate = DateTime.Now;
            this.ContractFinishDate = DateTime.Now;
            this.MountPerHour = 0;
            this.Name = "";
            this.LastName1 = "";
            this.LastName2 = "";
        }

        public JoinedTables(string PaymentInterval, string EmployeeEmail, string ContractType, DateTime ContractStartDate, DateTime ContractFinishDate, int MountPerHour, string Name, string LastName1, string LastName2)
        {
            this.PaymentInterval = PaymentInterval;
            this.EmployeeEmail = EmployeeEmail;
            this.ContractType = ContractType;
            this.ContractStartDate = ContractStartDate;
            this.ContractFinishDate = ContractFinishDate;
            this.MountPerHour = MountPerHour;
            this.Name = Name;
            this.LastName1 = LastName1;
            this.LastName2 = LastName2;
        }
    }
}