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
using ProjectManagement;
using ProjectManagement.Core.ViewModels;
using ProjectManagement.Adapters;
using Android.Views.InputMethods;
using ProjectManagement.Core;
using ProjectManagement.Core.Commons;
using Android.Support.Design.Widget;

namespace ProjectManagement.Fragments
{
    public class ProjectsFragment : BaseFragment
    {
        #region Variables
        private ProjectsViewModel _vm;
        private ProjectsAdapter projectsAdapter;
        #endregion

        #region Overrides
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            ((MainActivity)this.Activity).UnlockMenu();
            GetProjects();

            InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(View.WindowToken, 0);

            FloatingActionButton fabAdd = View.FindViewById<FloatingActionButton>(Resource.Id.fab_Projects_add);
            fabAdd.Click += FabAdd_Click;
        }

     
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.projects, container, false);
        }
        #endregion

        #region Methods

        internal override void InitViewModel()
        {
            _vm = new ProjectsViewModel(this);            
;        }

        private async void GetProjects()
        {
            try
            {
                List<Project> projectList = await _vm.GetProjects();

                //Set up adapter and stuff here
                projectsAdapter = new ProjectsAdapter(this.Activity, projectList);

                ListView listView = View.FindViewById<ListView>(Resource.Id.lv_projects);

                listView.ItemClick += listView_ItemClick;
                listView.Adapter = projectsAdapter;
            }
            catch (Exception e)
            {
                //Show exception message here
                Console.WriteLine("Exception occured. Reason:" + e.Message);
            }
        }
        #endregion

        #region Events
        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Navigate to the clicked project to view details
            if (projectsAdapter != null)
            {
                Project p = projectsAdapter[e.Position];
                ProjectDetailsFragment pf = new ProjectDetailsFragment();
                pf.SelectedProject = p;

                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.HomeFrameLayout, pf);
                ft.Commit();
            }
        }

        private void FabAdd_Click(object sender, EventArgs e)
        {

            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.HomeFrameLayout, new ProjectDetailsFragment());
            ft.Commit();
        }

        #endregion
    }
}