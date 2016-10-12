using ProjectManagement.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Services
{
    public class ProjectManagementServiceHelper : BaseServiceHelper
    {
        public static async Task<string> Authenticate(string username, string password)
        {
            var res = await DoPost<AuthenticateResponse>(new AuthenticateRequest() { password = password, username = username }, ServiceURLs.UserURL + "api-token-auth/");
            return res.token;
        }

        public static async Task<List<Project>> GetProjects(string token)
        {
            return await DoGet<List<Project>>(null, ServiceURLs.ProjectURL, token);
        }

        public static async Task<Project> AddProject(AddProjectRequest p , string token)
        {
            return await DoPost<Project>(p, ServiceURLs.ProjectURL, token);
        }
        public static async Task DeleteProject(int pk, string token)
        {
            await DoDelete(ServiceURLs.ProjectURL + pk + "/", token);
        }
        public static async Task<Project> UpdateProject(UpdateProjectRequest upr, string token)
        {
            return await DoPut<Project>(upr, ServiceURLs.ProjectURL + upr.ProjectID + "/", token);            
        }
    }
}
