using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Settings
{
    public class ProjectManagementSettings
    {
        private static ProjectManagementSettings _instance;

        public static ProjectManagementSettings Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ProjectManagementSettings();
                return _instance;
            }
        }

        public string Token { get; set; }
    }
}
