using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core
{
    public class Project
    {
        [JsonProperty(PropertyName = "pk")]
        public int ProjectID { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }
        [JsonProperty(PropertyName = "start_date")]
        public DateTime? StartDate { get; set; }
        [JsonProperty(PropertyName = "end_date")]
        public DateTime? EndDate { get; set; }
        [JsonProperty(PropertyName = "is_billable")]
        public bool IsBillable { get; set; }
        [JsonProperty(PropertyName = "is_active")]
        public bool IsActive { get; set; }
        [JsonProperty(PropertyName = "task_set")]
        public List<TaskItem> TaskSet { get; set; }
        [JsonProperty(PropertyName = "resource_set")]
        public List<ResourceItem> ResourceSet { get; set; }
    }
}
