using System.ComponentModel.DataAnnotations;

namespace FastFix2._0.Areas.Applications
{
    public class AnswersForApps
    { 
        public int Id { get; set; }
        public string Message { get; set; }
        public int Price { get; set; }
        public int AppID { get; set; }
        public string UserId { get; set; }
    }
}
