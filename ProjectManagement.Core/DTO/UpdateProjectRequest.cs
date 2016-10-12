using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.DTO
{
    public class UpdateProjectRequest
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

        public UpdateProjectRequest()
        {

        }

        public UpdateProjectRequest(Project p)
        {
            Title = p.Title;
            ProjectID = p.ProjectID;
            Description = p.Description;
            StartDate = p.StartDate;
            EndDate = p.EndDate;
            IsActive = p.IsActive;
            IsBillable = p.IsBillable;
        }
    }
}
