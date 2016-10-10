using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Core.Listeners
{
    public interface IProgressListener
    {
        void UpdateProgress(bool isBusy);
    }
}
