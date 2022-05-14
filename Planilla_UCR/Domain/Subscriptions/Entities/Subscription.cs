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
    public class Subscription : AggregateRoot
    {
        public String EmployerEmail { get; }
        public String NameSubscription { get; }
        public int Cost { get; }
        public int TypeSubscription { get; }
        

        public Subscription(String employerEmail, String nameSubscription, int cost, int typeSubscription)
        {
            EmployerEmail = employerEmail;
            NameSubscription = nameSubscription;
            Cost = cost;
            TypeSubscription = typeSubscription;
        }
        /*
        public Subscription(int id)
        {
            Id = id;
        }

        public Subscription(int id, String name)
        {
            Id = id;
            Subscription_Name = name;
        }*/
    }
}
