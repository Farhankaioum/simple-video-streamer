using Autofac;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Services;
using System;
using System.Collections.Generic;

namespace NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel
{
    public class SubscriptionIndexViewModel : AdminBaseModel
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public string Name { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public double Price { get; set; }
        public int DurationInMonth { get; set; }
        public DateTime CreatedAt { get; set; }

        public List<SubscriptionIndexViewModel> SubscriptionList { get; set; }

        public SubscriptionIndexViewModel()
        {
            _subscriptionTypeService = Startup.AutofacContainer.Resolve<ISubscriptionTypeService>();
            SubscriptionList = new List<SubscriptionIndexViewModel>();
        }

        public void LoadModelData()
        {
            var categories = _subscriptionTypeService.SubscriptionList();
            foreach (var category in categories)
            {
                SubscriptionList.Add(new SubscriptionIndexViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    ShortDescription = category.ShortDescription,
                    Price = category.Price,
                    DurationInMonth = category.DurationInMonth,
                    CreatedAt = category.CreatedAt
                });
            }
        }

        public void DeleteSubscription(int id)
        {
            var existingSubscription = _subscriptionTypeService.GetSubscriptionById(id);
            if (existingSubscription == null)
                throw new NotFoundException("Subscription package not found");

            _subscriptionTypeService.DeleteSubscription(existingSubscription);
        }
    }
}
