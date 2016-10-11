using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core
{
    public class ResourceItem
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "user")]
        public string UserID { get; set; }
        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty(PropertyName = "end_date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty(PropertyName = "rate")]
        public double Rate { get; set; }
        [JsonProperty(PropertyName = "agreed_hours_per_month")]
        public string AgreedHoursPerMonth { get; set; }
        [JsonProperty(PropertyName = "Created")]
        public DateTime? Created { get; set; }
        [JsonProperty(PropertyName = "updated")]
        public DateTime? Updated { get; set; }
        [JsonProperty(PropertyName = "project")]
        public int ProjectID { get; set; }
    }
}
