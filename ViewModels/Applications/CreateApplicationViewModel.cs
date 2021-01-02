using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FastFix2._0.ViewModels.Applications
{
    public class CreateApplicationViewModel
    {
        public string IssueTitle { get; set; }
        public string Car { get; set; }
        public DateTime RepairFrom { get; set; }
        public DateTime RepairTill { get; set; }
        public string TypeOfWork { get; set; }
        public string Description { get; set; }
    }
}
