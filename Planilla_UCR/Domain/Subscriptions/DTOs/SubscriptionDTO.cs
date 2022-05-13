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
        public int Id { get; }
        public String Subscription_Name { get; }
        public int Publication { get; }
        public String Group { get; }

        public SubscriptionDTO(int id, String name, int publication, String investigation_group)
        {
            Id = id;
            Subscription_Name = name;
            Publication = publication;
            Group = investigation_group;
        }

    }
}
