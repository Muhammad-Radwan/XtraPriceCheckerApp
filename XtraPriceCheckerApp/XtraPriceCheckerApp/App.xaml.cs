using System;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XtraPriceCheckerApp.Views;

namespace XtraPriceCheckerApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Preferences.Get("IPSettings", null)) || string.IsNullOrEmpty(Preferences.Get("PortSettings", null)))
            {
                MainPage = new SetingsView();
            } else
            {
                MainPage = new PriceCheckerView();
            }
            
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
