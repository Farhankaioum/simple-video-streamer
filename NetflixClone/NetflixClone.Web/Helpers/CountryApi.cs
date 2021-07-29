using System.Collections.Generic;

namespace NetflixClone.Web.Helpers
{
    public class CountryApi
    {
        public static List<CountryType> CountryTypes { get; set; } =
            new List<CountryType>
            {
                new CountryType { Name = "Bangladesh"},
                new CountryType { Name = "India"},
                new CountryType { Name = "Pakistan"},
                new CountryType { Name = "Nepal"},
                new CountryType { Name = "Bhutan"},
                new CountryType { Name = "Jordan"},
                new CountryType { Name = "Japan"},
                new CountryType { Name = "Saudia Arabia"},
                new CountryType { Name = "Englian"},
                new CountryType { Name = "Australiya"},
                new CountryType { Name = "Pakistan"},
                new CountryType { Name = "Indonesia"},
            };
    }
}
