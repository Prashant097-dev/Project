using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class ProductUser
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Company { get; set; }
        public string Category { get; set; }
        public double? Price { get; set; }
        public DateTime? DateOfManufacturing { get; set; }
        public string Colour { get; set; }
        public string Description { get; set; }
        public string EngineType { get; set; }
        public double? MileageKmpl { get; set; }
        public string CentralLocking { get; set; }
        public string BrakesType { get; set; }
        public string RearSuspension { get; set; }

        public virtual Category CategoryNavigation { get; set; }
        public virtual Company CompanyNavigation { get; set; }
    }
}
