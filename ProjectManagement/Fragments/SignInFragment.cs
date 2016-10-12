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
using Android.Support.V7.Widget;
using ProjectManagement;
using ProjectManagement.Fragments;
using ProjectManagement.Core.ViewModels;
using Android.Views.InputMethods;

namespace ProjectManagement.Fragments
{
    public class SignInFragment : BaseFragment
    {
        #region View Model
        private SignInViewModel _vm;
        #endregion

        #region Class Variables

        #endregion

        #region Control Variables
        private EditText edtUsername, edtPassword;
        #endregion

        #region Overrides
        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);

            //Lock the drawe till the user is logged in.
            ((MainActivity)this.Activity).LockMenu();
            //Initialize the views.
            InitView();
        }



        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            return inflater.Inflate(Resource.Layout.sign_in, container, false);
        }

        internal override void InitViewModel()
        {
            _vm = new SignInViewModel(this);
        }
        #endregion

        #region Methods
        private void InitView()
        {
            Button btnSign = View.FindViewById<Button>(Resource.Id.btn_login);
            btnSign.Click += BtnSign_Click;

            edtPassword = View.FindViewById<EditText>(Resource.Id.edt_signin_password);
            edtUsername = View.FindViewById<EditText>(Resource.Id.edt_signin_username);
        }

        private async void SignIn()
        {
            try
            {
                await _vm.SignIn(edtUsername.Text, edtPassword.Text);

                var ft = FragmentManager.BeginTransaction();
                ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
                ft.Commit();
            }
            catch(Exception e)
            {
                ShowErrorMessage(e.Message);
            }
           
        }
        #endregion

        #region Click Events

        private void BtnSign_Click(object sender, EventArgs e)
        {
            //var ft = FragmentManager.BeginTransaction();
            //ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
            //ft.Commit();
            SignIn();

        }
        #endregion

    }
}