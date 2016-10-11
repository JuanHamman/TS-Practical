
using System;
using Android.App;
using Android.OS;
using Android.Views;
using ProjectManagement.Core.Listeners;

namespace ProjectManagement.Fragments
{
    public abstract class BaseFragment : Fragment, IProgressListener
    {
        #region Properties
        public bool IsBusy { get; set; }

        #endregion

        #region Overrides

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return base.OnCreateView(inflater, container, savedInstanceState);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitViewModel();
        }

        #endregion

        internal abstract void InitViewModel();

        public void UpdateProgress(bool isBusy)
        {
           
        }
    }
}