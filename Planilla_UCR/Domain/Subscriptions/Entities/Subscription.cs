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
        public int Id { get; }
        public String Subscription_Name { get; }
        public int Publication { get; }
        public String Group { get; }

        public Subscription(int id, String name, int publication, String Group)
        {
            Id = id;
            Subscription_Name = name;
            Publication = publication;
            Group = Group;
        }

        public Subscription(int id)
        {
            Id = id;
        }

        public Subscription(int id, String name)
        {
            Id = id;
            Subscription_Name = name;
        }
    }
}
