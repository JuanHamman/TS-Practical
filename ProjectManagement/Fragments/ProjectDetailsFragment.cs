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
using ProjectManagement.Core.Commons;
using ProjectManagement.Core;
using ProjectManagement.Core.ViewModels;
using Android.Widget;
using System.Globalization;

namespace ProjectManagement.Fragments
{
    public class ProjectDetailsFragment : BaseFragment
    {
        #region Variables
        public Project SelectedProject{ get; set; }
        private ProjectDetailsViewModel _vm;
        #endregion

        #region Class Variables
        private EditText edtTitle, edtDescription, edtStartDate, edtEndDate;
        private CheckBox cbIsBillable, cbIsActive;
        private AlertDialog deleteDialog;
        #endregion

        #region Overerides
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            InitView();
            PopulateProjectDetails();

        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetHasOptionsMenu(true);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            return inflater.Inflate(Resource.Layout.project_details, container, false);
        }

        public override void OnCreateOptionsMenu(IMenu menu, MenuInflater inflater)
        {           
            inflater.Inflate(Resource.Menu.action_menu, menu);
            base.OnCreateOptionsMenu(menu, inflater);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.nv_Delete:
                    ShowConfirmationDialog();                  
                    break;
                default:
                    break;
            }
            return base.OnOptionsItemSelected(item);
            
        }       

        #endregion

        #region Methods

        private void InitView()
        {
            //Edit Fields
            edtTitle = View.FindViewById<EditText>(Resource.Id.edit_projectdetails_title);
            edtDescription = View.FindViewById<EditText>(Resource.Id.edit_projectdetails_description);
            edtStartDate = View.FindViewById<EditText>(Resource.Id.edit_projectdetails_startDate);
            edtStartDate.Click += EdtStartDate_Click;
            edtEndDate = View.FindViewById<EditText>(Resource.Id.edit_projectdetails_endDate);
            edtEndDate.Click += EdtEndDate_Click;

            //CheckBoxes
            cbIsActive = View.FindViewById<CheckBox>(Resource.Id.cb_projectdetails_IsActive);
            cbIsBillable = View.FindViewById<CheckBox>(Resource.Id.cb_projectdetails_IsBillable);

            //Buttons
            Button btnback = View.FindViewById<Button>(Resource.Id.btn_projectdetails_Back);
            btnback.Click += Btnback_Click;

            Button btnSave = View.FindViewById<Button>(Resource.Id.btn_projectdetails_Add);
            btnSave.Click += BtnSave_Click;
        }

        private void PopulateProjectDetails()
        {
            DateTime dtStart, dtEnd;          

            if (SelectedProject != null)
            {
                edtTitle.Text = SelectedProject.Title;
                edtDescription.Text = SelectedProject.Description;
                if(SelectedProject.StartDate != null && SelectedProject.EndDate != null)
                {
                    dtStart = SelectedProject.StartDate.Value.Date;
                    dtEnd = SelectedProject.EndDate.Value.Date;

                    edtStartDate.Text = dtStart.Date.ToShortDateString();
                    edtEndDate.Text = dtEnd.Date.ToShortDateString();
                }
                cbIsActive.Checked = SelectedProject.IsActive;
                cbIsBillable.Checked = SelectedProject.IsBillable;
            }
        }

        private async void AddProject()
        {
            try
            {
                Project p = new Project();
                //Assign values
                p.Title = edtTitle.Text;
                p.Description = edtDescription.Text;
                p.StartDate = DateTime.ParseExact(edtStartDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                p.EndDate = DateTime.ParseExact(edtEndDate.Text, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                p.IsActive = cbIsActive.Checked;
                p.IsBillable = cbIsBillable.Checked;

                await _vm.AddProject(p);
                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
                ft.Commit();
            }
            catch (Exception e)
            {
                ShowErrorMessage(e.Message);
            }


        }

        private async void UpdateProject()
        {
            DateTime dtStart = DateTime.Parse(edtStartDate.Text);
            DateTime dtEnd = DateTime.Parse(edtEndDate.Text);
            try
            {
                SelectedProject.Description = edtDescription.Text;
                SelectedProject.Title = edtTitle.Text;
                SelectedProject.StartDate = dtStart.Date;
                SelectedProject.EndDate = dtEnd.Date;
                SelectedProject.IsActive = cbIsActive.Checked;
                SelectedProject.IsBillable = cbIsBillable.Checked;

                await _vm.UpdateProject(SelectedProject);
                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
                ft.Commit();
            }
            catch(Exception e)
            {
                ShowErrorMessage(e.Message);
            }
         
        }

        private async void DeleteProject()
        {
            await _vm.DeleteProject(SelectedProject);

            var ft = FragmentManager.BeginTransaction();
            ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
            ft.Commit();

        }

        internal override void InitViewModel()
        {
            _vm = new ProjectDetailsViewModel(this);
        }

        private void ShowConfirmationDialog()
        {
            AlertDialog.Builder builder = new AlertDialog.Builder(this.Activity);
            builder.SetMessage("Do you want to delete this project?");
            builder.SetCancelable(false);
            builder.SetPositiveButton("Yes", DeleteDialogPositive);
            builder.SetNegativeButton("No", DelteDialogNegative);
            deleteDialog = builder.Create();
            deleteDialog.Show();
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
            if (SelectedProject == null)
            {
                AddProject();
            }
            else
                UpdateProject();
        }

        private void EdtEndDate_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            DatePickerDialog EndDate = new Android.App.DatePickerDialog(this.Activity, EndDateSet, d.Year, d.Month - 1, d.Day);
            EndDate.Show();
        }

        private void EdtStartDate_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            DatePickerDialog StartDate = new Android.App.DatePickerDialog(this.Activity, StartDateSet, d.Year, d.Month - 1, d.Day);
            StartDate.Show();
        }

        private void StartDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            edtStartDate.Text = e.Date.ToString("yyyy-MM-dd");
        }

        public void EndDateSet(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            edtEndDate.Text = e.Date.ToString("yyyy-MM-dd");
        }

        private void DelteDialogNegative(object sender, DialogClickEventArgs e)
        {

        }

        private void DeleteDialogPositive(object sender, DialogClickEventArgs e)
        {
            DeleteProject();
        }
        #endregion
    }
}