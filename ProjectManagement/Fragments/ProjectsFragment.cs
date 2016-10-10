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
            //GetProjects(); //Getting the list trough the web service 
            PopulateList();

            InputMethodManager imm = (InputMethodManager)Activity.GetSystemService(Context.InputMethodService);
            imm.HideSoftInputFromWindow(View.WindowToken, 0);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.projects, container, false);
        }
        #endregion

        #region Methods
        private void PopulateList()
        {
            projectsAdapter = new ProjectsAdapter(this.Activity, GetItems());

            ListView listView = View.FindViewById<ListView>(Resource.Id.lv_projects);

            listView.ItemClick += listView_ItemClick;
            listView.Adapter = projectsAdapter;
        }

        private List<Projects> GetItems()
        {
            List<Projects> projectList = new List<Projects>();
            projectList.Add(new Projects() { ProjectName = "Juan's company" });
            projectList.Add(new Projects() { ProjectName = "Wiehan's company" });
            projectList.Add(new Projects() { ProjectName = "Liep's company" });
            projectList.Add(new Projects() { ProjectName = "Louis company" });
            return projectList;
        }

        internal override void InitViewModel()
        {
            _vm = new ProjectsViewModel(this);
        }

        private async void GetProjects()
        {
            await _vm.GetProjects();
        }
        #endregion

        #region Events
        private void listView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            //Navigate to the clicked project to view details
            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.HomeFrameLayout, new ProjectDetailsFragment());
            ft.Commit();
        }
        #endregion
    }
}