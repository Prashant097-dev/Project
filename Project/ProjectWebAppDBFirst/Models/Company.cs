using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class Company
    {
        public Company()
        {
            CustomDesigns = new HashSet<CustomDesign>();
            FuturisticApproaches = new HashSet<FuturisticApproach>();
            ProductMerchants = new HashSet<ProductMerchant>();
            ProductUsers = new HashSet<ProductUser>();
            ServiceCenters = new HashSet<ServiceCenter>();
        }

        public int? CompanyId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CustomDesign> CustomDesigns { get; set; }
        public virtual ICollection<FuturisticApproach> FuturisticApproaches { get; set; }
        public virtual ICollection<ProductMerchant> ProductMerchants { get; set; }
        public virtual ICollection<ProductUser> ProductUsers { get; set; }
        public virtual ICollection<ServiceCenter> ServiceCenters { get; set; }
    }
}
