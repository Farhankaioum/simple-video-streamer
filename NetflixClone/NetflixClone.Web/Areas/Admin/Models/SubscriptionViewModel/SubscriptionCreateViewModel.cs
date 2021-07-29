using Autofac;
using NetflixClone.Foundation.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel
{
    public class SubscriptionCreateViewModel : AdminBaseModel
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Required]
        public double? Price { get; set; }

        [Required]
        [Display(Name = "Package Duration")]
        public int? DurationInMonth { get; set; }

        public SubscriptionCreateViewModel()
        {
            _subscriptionTypeService = Startup.AutofacContainer.Resolve<ISubscriptionTypeService>();
        }

        public void CreateSubscription()
        {
            _subscriptionTypeService.AddSubscription(
                new Foundation.Entities.SubscriptionType 
                {
                    Name = Name,
                    Description = Description,
                    ShortDescription = ShortDescription,
                    Price = Price.Value,
                    DurationInMonth = DurationInMonth.Value,
                    CreatedAt = DateTime.Now
                });
        }
    }
}
