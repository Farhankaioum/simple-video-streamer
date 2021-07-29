using Autofac;
using NetflixClone.Foundation.Entities;
using NetflixClone.Foundation.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NetflixClone.Web.Models.SubscriptionViewModel
{
    public class SubscriptionIndexViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public int DurationInMonth { get; set; }
        public DateTime CreatedAt { get; set; }

        public IList<SubscriptionIndexViewModel> SubscriptionList { get; set; }

        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public SubscriptionIndexViewModel()
        {
            _subscriptionTypeService = Startup.AutofacContainer.Resolve<ISubscriptionTypeService>();
            SubscriptionList = new List<SubscriptionIndexViewModel>();
        }

        public void LoadModelData()
        {
            var subscriptionList = _subscriptionTypeService.SubscriptionList();

            foreach(var subscription in subscriptionList)
            {
                SubscriptionList.Add(new SubscriptionIndexViewModel
                {
                    Id = subscription.Id,
                    Name = subscription.Name,
                    Description = subscription.Description,
                    ShortDescription = subscription.ShortDescription,
                    Price = subscription.Price,
                    DurationInMonth = subscription.DurationInMonth,
                    CreatedAt = CreatedAt
                });
            }
        }

        public async Task<bool> AddUserSubscription(string userId, int subscriptionId)
        {
            return await _subscriptionTypeService.AddUserSubscription(userId, subscriptionId);
        }
    }
}
