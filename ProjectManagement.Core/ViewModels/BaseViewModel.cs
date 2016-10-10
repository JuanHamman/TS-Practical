using ProjectManagement.Core.Listeners;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.ViewModels
{
    public class BaseViewModel
    {
        private IProgressListener _listener;
        public BaseViewModel(IProgressListener listener)
        {
            _listener = listener;
        }

        public void ShowProgress()
        {
            _listener.UpdateProgress(true);
        }

        public void HideProgress()
        {
            _listener.UpdateProgress(false);
        }
    }
}
