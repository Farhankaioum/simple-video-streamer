using Autofac;
using NetflixClone.Foundation.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel
{
    public class SubscriptionCreateViewModel
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        [Required]
        public string Name { get; set; }

        public SubscriptionCreateViewModel()
        {
            _subscriptionTypeService = Startup.AutofacContainer.Resolve<ISubscriptionTypeService>();
        }

        public void CreateSubscription()
        {
            _subscriptionTypeService.AddSubscription(
                new Foundation.Entities.SubscriptionType { Name = Name, CreatedAt = DateTime.Now});
        }
    }
}
