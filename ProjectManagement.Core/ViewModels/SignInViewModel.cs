using ProjectManagement.Core.Listeners;
using ProjectManagement.Core.Services;
using ProjectManagement.Core.Settings;
using System;
using System.Threading.Tasks;

namespace ProjectManagement.Core.ViewModels
{
    public class SignInViewModel : BaseViewModel
    {
        public SignInViewModel(IProgressListener listener) : base(listener)
        {
        }

        public async Task SignIn(string username, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(username))
                    throw new Exception("Username can not be empty.");
                ShowProgress();
                string token = await ProjectManagementServiceHelper.Authenticate(username, password);
                ProjectManagementSettings.Instance.Token = token;
                HideProgress();
            }
            catch (Exception)
            {                
                HideProgress();
                throw;
            }
        }
    }
}
