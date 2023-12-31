﻿using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TravelAway.DAL.Models
{
    public partial class PackageDetails
    {
        public PackageDetails()
        {
            Customers = new HashSet<Customers>();
        }

        public string PackageDetailsId { get; set; }
        public string PackageId { get; set; }
        public string PlacesToVisit { get; set; }
        public string PackageDescription { get; set; }
        public string DaysAndNight { get; set; }
        public int Price { get; set; }
        public string Accommodation { get; set; }

        public virtual Packages Package { get; set; }
        public virtual ICollection<Customers> Customers { get; set; }
    }
}
