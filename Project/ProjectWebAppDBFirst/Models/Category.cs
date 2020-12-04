using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class Category
    {
        public Category()
        {
            CustomDesigns = new HashSet<CustomDesign>();
            FuturisticApproaches = new HashSet<FuturisticApproach>();
            ProductMerchants = new HashSet<ProductMerchant>();
            ProductUsers = new HashSet<ProductUser>();
            ServiceCenters = new HashSet<ServiceCenter>();
        }

        public int? CategoryId { get; set; }
        public string Category1 { get; set; }

        public virtual ICollection<CustomDesign> CustomDesigns { get; set; }
        public virtual ICollection<FuturisticApproach> FuturisticApproaches { get; set; }
        public virtual ICollection<ProductMerchant> ProductMerchants { get; set; }
        public virtual ICollection<ProductUser> ProductUsers { get; set; }
        public virtual ICollection<ServiceCenter> ServiceCenters { get; set; }
    }
}
