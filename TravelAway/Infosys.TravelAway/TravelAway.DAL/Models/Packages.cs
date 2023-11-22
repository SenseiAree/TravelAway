using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelAway.DAL.Models
{
    public partial class Packages
    {
        public Packages()
        {
            PackageDetails = new HashSet<PackageDetails>();
        }

        public string PackageId { get; set; }
        public string PackageName { get; set; }
        public string PackageDesc { get; set; }
        public string PackageAvatar { get; set; }
        public string TypeOfPackage { get; set; }
        public string CategoryId { get; set; }

        public virtual PackageCategories Category { get; set; }
        public virtual ICollection<PackageDetails> PackageDetails { get; set; }
    }
}
