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

        public static async Task GetProjects(string token)
        {
            var res = await DoGet<AuthenticateRequest>(null, ServiceURLs.ProjectURL, token);
        }
    }
}
