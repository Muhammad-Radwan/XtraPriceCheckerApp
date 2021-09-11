using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Android.Views.InputMethods;
using Android.Views;

namespace XtraPriceCheckerApp.Droid
{
    [Activity(Label = "XtraPriceCheckerApp", Icon = "@drawable/barcode_scanner", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            InputMethodManager imm = (InputMethodManager)this.GetSystemService(Activity.InputMethodService);
            //Find the currently focused view, so we can grab the correct window token from it.
            View view = this.CurrentFocus;
            //If no view currently has focus, create a new one, just so we can grab a window token from it
            if (view == null)
            {
                view = new View(this);
            }
            imm.HideSoftInputFromWindow(view.WindowToken, 0);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}