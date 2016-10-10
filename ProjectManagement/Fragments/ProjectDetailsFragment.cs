using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace ProjectManagement.Fragments
{
    public class ProjectDetailsFragment : Fragment
    {
        #region Variables

        #endregion

        #region Overerides
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitView();
            PopulateProjectDetails();

        }

       

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.project_details, container, false);
        }


        #endregion

        #region Methods

        private void InitView()
        {
            Button btnback = View.FindViewById<Button>(Resource.Id.btn_projectdetails_Back);
            btnback.Click += Btnback_Click;

            Button btnSave = View.FindViewById<Button>(Resource.Id.btn_projectdetails_Add);
            btnSave.Click += BtnSave_Click;
        }

        

        private void PopulateProjectDetails()
        {
            
        }
        #endregion

        #region Events
        private void Btnback_Click(object sender, EventArgs e)
        {
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
            ft.Commit();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
           //Save details and navigate back to projects fragment
        }
        #endregion
    }
}