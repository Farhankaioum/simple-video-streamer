using Autofac;
using NetflixClone.Foundation.Services;
using System.Collections.Generic;

namespace NetflixClone.Web.Areas.Admin.Models.SubscriptionViewModel
{
    public class SubscriptionIndexViewModel
    {
        private readonly ISubscriptionTypeService _subscriptionTypeService;

        public string Name { get; set; }
        public int Id { get; set; }

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
                    Name = category.Name
                });
            }
        }
    }
}
