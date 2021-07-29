using System;
using System.Collections.Generic;

namespace NetflixClone.Foundation.Entities
{
    public class SubscriptionType : IEntity<int>
    {
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual string ShortDescription { get; set; }
        public virtual double Price { get; set; }
        public virtual int DurationInMonth { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual IList<ApplicationUser> ApplicationUsers { get; set; }

        public SubscriptionType()
        {
            ApplicationUsers = new List<ApplicationUser>();
        }
    }
}
