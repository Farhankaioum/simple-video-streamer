using NetflixClone.Foundation.Entities;
using System;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Services
{
    public interface ISubscriptionTypeService
    {
        void AddSubscription(SubscriptionType subscription);
        IList<SubscriptionType> SubscriptionList();
        SubscriptionType GetSubscriptionById(int id);
        void UpdateSubscription(SubscriptionType subscription);
        void DeleteSubscription(SubscriptionType subscription);
    }
}
