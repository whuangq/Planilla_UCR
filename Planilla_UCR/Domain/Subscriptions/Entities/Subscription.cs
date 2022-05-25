using System;

namespace Domain.Subscriptions.Entities
{
    public class Subscription
    {
        public String EmployerEmail { get; set; }
        public String ProjectName { get; set; }
        public String SubscriptionName { get; set; }
        public String ProviderName { get; set; }
        public String SubscriptionDescription { get; set; }
        public int Cost { get; set; }
        public int TypeSubscription { get; set; }
        public int IsEnabled { get; set; }


        public Subscription(String employerEmail, String projectName,
            String subscriptionName, String providerName,
            String subscriptionDescription, int cost, int typeSubscription, int isEnabled)
        {
            EmployerEmail = employerEmail;
            ProjectName = projectName;
            SubscriptionName = subscriptionName;
            ProviderName = providerName;
            SubscriptionDescription = subscriptionDescription;
            Cost = cost;
            TypeSubscription = typeSubscription;
            IsEnabled = isEnabled;
        }
    }
}
