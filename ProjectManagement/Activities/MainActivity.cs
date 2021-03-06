﻿using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.App;
using System;
using ProjectManagement.Fragments;
using Android.Views.InputMethods;
using Android.Content;

//This is the Practical assignment of Juan Hamman for Tangent Solutions.

namespace ProjectManagement
{
	[Activity (Label = "Project Management", MainLauncher = true)]
	public class MainActivity : AppCompatActivity
	{

        #region Variables
        private DrawerLayout drawerLayout;
        private ActionBarDrawerToggle drawerToggle;
        #endregion

        #region Overrides
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);         
            InitDrawer();
        }

        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }   
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
            {
                FragmentManager.PopBackStack();
            }
            else {
                base.OnBackPressed();
            }
        }
        #endregion

        #region Methods
        private void InitDrawer()
        {
            drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            // Init toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            // Attach item selected handler to navigation view
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerLayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            //load default home screen
            var ft = FragmentManager.BeginTransaction();
            ft.AddToBackStack(null);
            ft.Add(Resource.Id.HomeFrameLayout, new SignInFragment());
            ft.Commit();
        }

        public void LockMenu()
        {
            try
            {
                if (null != drawerLayout)
                    drawerLayout.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);
                if (null != drawerToggle)
                    drawerToggle.DrawerIndicatorEnabled = false;
                if (null != SupportActionBar)
                    SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            }
            catch (Exception e)
            {
                Console.WriteLine("An exception occured while locking the menu - " + e.StackTrace);
            }
        }

        public void UnlockMenu()
        {
            try
            {
                if (null != SupportActionBar)
                    SupportActionBar.SetDisplayHomeAsUpEnabled(true);

                if (null != drawerLayout)
                    drawerLayout.SetDrawerLockMode(DrawerLayout.LockModeUnlocked);

                if (null != drawerToggle)
                    drawerToggle.DrawerIndicatorEnabled = true;
            }
            catch (Exception e)
            {
                System.Console.WriteLine("An exception occured while un-locking the menu - " + e.StackTrace);
            }
        }
        #endregion

        #region Events
        void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            var ft = FragmentManager.BeginTransaction();
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_Projects):
                    ft.Replace(Resource.Id.HomeFrameLayout, new ProjectsFragment());
                    break;
                case (Resource.Id.nav_Logout):
                    ft.Replace(Resource.Id.HomeFrameLayout, new SignInFragment());
                    break;
            }
            ft.Commit();
            drawerLayout.CloseDrawers();
        }
        #endregion


    }
}


