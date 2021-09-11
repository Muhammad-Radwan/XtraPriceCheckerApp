using Android.Media;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XtraPriceCheckerClient
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            
            CheckPermission();
            MainPage = new MainPage();
        }


        private async void CheckPermission()
        {
            var state = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (state != PermissionStatus.Granted)
                await Permissions.RequestAsync<Permissions.Camera>();
        }
        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
