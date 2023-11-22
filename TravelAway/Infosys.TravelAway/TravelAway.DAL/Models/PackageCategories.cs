using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelAway.DAL.Models
{
    public partial class PackageCategories
    {
        public PackageCategories()
        {
            Packages = new HashSet<Packages>();
        }

        public string CategoryId { get; set; }
        public string CategoryName { get; set; }

        public virtual ICollection<Packages> Packages { get; set; }
    }
}
