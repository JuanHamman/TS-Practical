using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Core.Listeners;
using ProjectManagement.Core.Services;
using ProjectManagement.Core.DTO;
using ProjectManagement.Core.Settings;

namespace ProjectManagement.Core.ViewModels
{
    public class ProjectDetailsViewModel : BaseViewModel
    {
        public ProjectDetailsViewModel(IProgressListener listener) : base(listener)
        {
            
        }

        public async Task AddProject(Project p)
        {
            try
            {
                ShowProgress();
                await ProjectManagementServiceHelper.AddProject(new AddProjectRequest(p), ProjectManagementSettings.Instance.Token);
                HideProgress();
            }
            catch (Exception e)
            {
                HideProgress();
                throw e;
                //Add better error handling
            }  
        }

        public async Task UpdateProject(Project p)
        {
            try
            {
                ShowProgress();
                await ProjectManagementServiceHelper.UpdateProject(new UpdateProjectRequest(p), ProjectManagementSettings.Instance.Token);
                HideProgress();
            }
            catch (Exception e)
            {
                HideProgress();
                throw e;
                //Add better error handling
            }
        }

        public async Task DeleteProject(Project p)
        {
            try
            {
                ShowProgress();
                await ProjectManagementServiceHelper.DeleteProject(p.ProjectID, ProjectManagementSettings.Instance.Token);
                HideProgress();
            }
            catch (Exception e)
            {
                HideProgress();
                throw e;
                //Add better error handling
            }
        }
    }
}
