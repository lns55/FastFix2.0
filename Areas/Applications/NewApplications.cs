using System;

namespace FastFix2._0.Data
{
    public class NewApplications
    {
        public int Id { get; set; }
        public string IssueTitle { get; set; }
        public string Car { get; set; }
        public DateTime RepairFrom { get; set; }
        public DateTime RepairTill { get; set; }
        public string City { get; set; }
        public string TypeOfWork { get; set; }
        public string Description { get; set; }
    }
}