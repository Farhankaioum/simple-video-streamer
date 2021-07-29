using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetflixClone.Foundation.Services
{
    public class SubscriptionTypeService : ISubscriptionTypeService
    {
        private readonly IRepository<SubscriptionType, int> _repository;

        public SubscriptionTypeService(IRepository<SubscriptionType, int> repository)
        {
            _repository = repository;
        }

        public void AddSubscription(SubscriptionType subscription)
        {
            var count = _repository.GetCount(x => x.Name == subscription.Name);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }
            _repository.Insert(subscription);
        }

        public void DeleteSubscription(SubscriptionType subscription)
        {
            _repository.Delete(subscription);
        }

        public SubscriptionType GetSubscriptionById(int id)
        {
            return _repository.GetById(id);
        }

        public IList<SubscriptionType> SubscriptionList()
        {
            return _repository.GetList();
        }

        public void UpdateSubscription(SubscriptionType subscription)
        {
            var count = _repository.GetCount(x => x.Name == subscription.Name && x.Id != subscription.Id);

            if (count > 0)
            {
                throw new DuplicationException("Name Already Exists");
            }

            _repository.Update(subscription);
        }
    }
}
