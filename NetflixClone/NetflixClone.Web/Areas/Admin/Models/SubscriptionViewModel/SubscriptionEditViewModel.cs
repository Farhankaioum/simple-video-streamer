using Autofac;
using NetflixClone.Foundation.Exceptions;
using NetflixClone.Foundation.Services;
using System;
using System.ComponentModel.DataAnnotations;

namespace NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel
{
    public class SubscriptionEditViewModel : AdminBaseModel
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public int Id { get; set; }

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

        public SubscriptionEditViewModel()
        {
            _subscriptionTypeService = Startup.AutofacContainer.Resolve<ISubscriptionTypeService>();
        }

        public void EditSubscription()
        {
            var existingSubscription = _subscriptionTypeService.GetSubscriptionById(Id);
            if (existingSubscription == null)
                throw new NotFoundException("Subscription package not found");

            existingSubscription.Name = Name;
            existingSubscription.Description = Description;
            existingSubscription.ShortDescription = ShortDescription;
            existingSubscription.Price = Price.Value;
            existingSubscription.DurationInMonth = DurationInMonth.Value;

            _subscriptionTypeService.UpdateSubscription(existingSubscription);
        }

        public void GetSubscriptionById(int id)
        {
            var existingSubscription = _subscriptionTypeService.GetSubscriptionById(id);
            if (existingSubscription == null)
                throw new NotFoundException("Subscription package not found");

            Id = existingSubscription.Id;
            Name = existingSubscription.Name;
            Description = existingSubscription.Description;
            ShortDescription = existingSubscription.ShortDescription;
            Price = existingSubscription.Price;
            DurationInMonth = existingSubscription.DurationInMonth;
        }
    }
}
