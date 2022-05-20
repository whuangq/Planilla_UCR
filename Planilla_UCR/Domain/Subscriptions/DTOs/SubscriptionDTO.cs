using System;

namespace Domain.Subscriptions.DTOs
{
    public class SubscriptionDTO
    {
        public String EmployerEmail { get; set; }
        public String NameSubscription { get; set; }
        public String ProviderName { get; set; }
        public String SubscriptionDescription { get; set; }
        public int Cost { get; set; }
        public int TypeSubscription { get; set; }

        public SubscriptionDTO(String employerEmail, String nameSubscription, String providerName, String subscriptionDescription, int cost, int typeSubscription)
        {
            EmployerEmail = employerEmail;
            NameSubscription = nameSubscription;
            ProviderName = providerName;
            SubscriptionDescription = subscriptionDescription;
            Cost = cost;
            TypeSubscription = typeSubscription;
        }

    }
}
