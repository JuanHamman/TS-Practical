
using System;
using Android.App;
using Android.OS;
using Android.Views;
using ProjectManagement.Core.Listeners;
using Android.Views.InputMethods;
using Android.InputMethodServices;

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

        #region Methods
        internal abstract void InitViewModel();

        public void UpdateProgress(bool isBusy)
        {
            //TODO: implement global progress controls
            View content = Activity.FindViewById(Resource.Id.HomeFrameLayout);
            View progress = Activity.FindViewById(Resource.Id.progress);
            if (content != null && progress != null)
            {
                Activity.RunOnUiThread(() =>
                {
                    IsBusy = isBusy;
                    if (isBusy)
                    {
                        content.Visibility = ViewStates.Gone;
                        progress.Visibility = ViewStates.Visible;
                        InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Activity.InputMethodService);
                        imm.HideSoftInputFromWindow(content.WindowToken, HideSoftInputFlags.None);
                    }
                    else
                    {
                        content.Visibility = ViewStates.Visible;
                        progress.Visibility = ViewStates.Gone;
                    }
                });
            }
        }

        internal void ShowErrorMessage(string message)
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(Activity);
            builder.SetTitle("Oops...");
            builder.SetMessage(message);
            builder.SetPositiveButton("OK", (s, e) => { });
            builder.SetCancelable(false);
            builder.Create().Show();

        }
        #endregion
    }
}