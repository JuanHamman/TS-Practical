using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core
{
    public class TaskItem
    {
        [JsonProperty(PropertyName = "id")]
        public int ID { get; set; }
        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }
        [JsonProperty(PropertyName = "due_date")]
        public DateTime? DueDate { get; set; }
        [JsonProperty(PropertyName = "estimated_hours")]
        public string EstimatedHours { get; set; }
        [JsonProperty(PropertyName = "project")]
        public int ProjectID { get; set; }
        [JsonProperty(PropertyName = "project_data")]
        public Project ProjectData { get; set; }
    }

}
