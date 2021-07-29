using NetflixClone.Foundation.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetflixClone.Foundation.Services
{
    public interface ISubscriptionTypeService
    {
        void AddSubscription(SubscriptionType subscription);
        IList<SubscriptionType> SubscriptionList();
        SubscriptionType GetSubscriptionById(int id);
        void UpdateSubscription(SubscriptionType subscription);
        void DeleteSubscription(SubscriptionType subscription);
        Task<bool> AddUserSubscription(string userId, int subscriptionId);
    }
}
