using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Commons
{
   public class ProjectManagementCommons
    {
        private static ProjectManagementCommons instance;
        public static ProjectManagementCommons Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ProjectManagementCommons();
                }
                return instance;
            }
        }

        #region App Variables
        public Project project { get; set; }
        #endregion
    }
}
