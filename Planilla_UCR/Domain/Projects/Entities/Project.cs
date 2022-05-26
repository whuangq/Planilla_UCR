using System;


namespace Domain.Projects.Entities
{
    public class Project
    {
        public String EmployerEmail { set; get; }
        public String ProjectName { set; get; }
        public String ProjectDescription { set; get; }
        public int MaximumAmountForBenefits { set; get; }
        public int MaximumBenefitAmount { set; get; }
        public String PaymentInterval { set; get; }

        public Project(String employerEmail, String projectName,
                        String projectDescription, int maximumAmountForBenefits,
                        int maximumBenefitAmount, String paymentInterval)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            ProjectDescription = projectDescription;
            MaximumAmountForBenefits = maximumAmountForBenefits;
            MaximumBenefitAmount = maximumBenefitAmount;
            PaymentInterval = paymentInterval;
        }

    }
}
