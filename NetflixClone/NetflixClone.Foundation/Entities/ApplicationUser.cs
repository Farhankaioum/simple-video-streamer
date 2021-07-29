using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetflixClone.Foundation.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(80)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; }

        [MaxLength(60)]
        public string Country { get; set; }

        [MaxLength(60)]
        public string City { get; set; }

        [MaxLength(150)]
        public string CompanyName { get; set; }

        [ForeignKey("SubscriptionTypeId")]
        public SubscriptionType SubscriptionType { get; set; }
        public int? SubscriptionTypeId { get; set; }

        public DateTime SubscriptionDate { get; set; }
    }
}
