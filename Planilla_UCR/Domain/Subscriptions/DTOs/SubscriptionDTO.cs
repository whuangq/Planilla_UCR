using Domain.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Subscriptions.DTOs
{
    public class SubscriptionDTO
    {
        public String EmployerEmail { get; }
        public String NameSubscription { get; }
        public int Cost { get; }
        public int TypeSubscription { get; }

        public SubscriptionDTO(String employerEmail, String nameSubscription, int cost, int typeSubscription)
        {
            EmployerEmail = employerEmail;
            NameSubscription = nameSubscription;
            Cost = cost;
            TypeSubscription = typeSubscription;
        }

    }
}
