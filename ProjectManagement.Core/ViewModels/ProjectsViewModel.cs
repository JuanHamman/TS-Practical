﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectManagement.Core.Listeners;
using ProjectManagement.Core.Services;
using ProjectManagement.Core.Settings;
using ProjectManagement.Core.DTO;

namespace ProjectManagement.Core.ViewModels
{
    public class ProjectsViewModel : BaseViewModel
    {
        public ProjectsViewModel(IProgressListener listener) : base(listener)
        {
        }

        public async Task<List<Project>> GetProjects()
        {
            try
            {
             return await ProjectManagementServiceHelper.GetProjects(ProjectManagementSettings.Instance.Token);              
            }
            catch (Exception e)
            {
                throw e; 
                //Add better error handling
            }
        }
    }
}
