using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class ServiceCenter
    {
        public int ServiceCenterId { get; set; }
        public string Name { get; set; }
        public string CompanyType { get; set; }
        public string Location { get; set; }
        public string CategoryType { get; set; }
        public string ContactNumber { get; set; }
        public string Timings { get; set; }
        public string CertifiedBy { get; set; }

        public virtual Category CategoryTypeNavigation { get; set; }
        public virtual Company CompanyTypeNavigation { get; set; }
    }
}
