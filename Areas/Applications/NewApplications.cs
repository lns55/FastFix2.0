﻿using FastFix2._0.Areas.Identity;
using System;

namespace FastFix2._0.Areas.Applications
{
    public class NewApplications
    {
        public int Id { get; set; }
        public string IssueTitle { get; set; }
        public string Car { get; set; }
        public string RepairFrom { get; set; }
        public DateTime RepairTill { get; set; }
        public string City { get; set; }
        public string TypeOfWork { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }
    }
}