﻿using Xamarin.Forms;

namespace HelloWorldApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            //MainPage = new HelloWorldAppPage();
            MainPage = new HelloWorldPage();
            //MainPage = new HelloTabbedPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
