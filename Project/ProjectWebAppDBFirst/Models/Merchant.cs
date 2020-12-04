using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class Merchant
    {
        public Merchant()
        {
            ProductMerchants = new HashSet<ProductMerchant>();
        }

        public int MerchantId { get; set; }
        public string MerchantPassword { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public string Address { get; set; }
        public double? MerchantPin { get; set; }
        public string MerchantLocation { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string ContactNumber { get; set; }

        public virtual ICollection<ProductMerchant> ProductMerchants { get; set; }
    }
}
