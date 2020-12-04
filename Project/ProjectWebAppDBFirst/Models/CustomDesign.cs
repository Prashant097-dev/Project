using System;
using System.Collections.Generic;

#nullable disable

namespace ProjectWebAppDBFirst.Models
{
    public partial class CustomDesign
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CompanyType { get; set; }
        public string CategoryType { get; set; }
        public string Description { get; set; }

        public virtual Category CategoryTypeNavigation { get; set; }
        public virtual Company CompanyTypeNavigation { get; set; }
    }
}
