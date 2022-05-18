using Domain.Core.Entities;
using Domain.Core.ValueObjects;
using Domain.Subscriptions.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subscriptions.Entities
{
    public class Subscription
    {
        public String EmployerEmail { get; set; }
        public String NameSubscription { get; set; }
        public String ProviderName { get; set; }
        public String SubscriptionDescription { get; set; }
        public int Cost { get; set; }
        public int TypeSubscription { get; set; }


        public Subscription(String employerEmail, String nameSubscription, String providerName, String subscriptionDescription, int cost, int typeSubscription)
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