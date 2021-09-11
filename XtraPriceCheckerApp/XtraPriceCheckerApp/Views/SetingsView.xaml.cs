using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XtraPriceCheckerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SetingsView : ContentPage
    {
        public SetingsView()
        {
            InitializeComponent();
            IPSetting.Text = Preferences.Get("IPSettings", null);
            PortSetting.Text = Preferences.Get("PortSettings", null);
        }

        private void SaveSettings(string ip, string port, string shopSettings)
        {
            Preferences.Set("IPSettings", ip);
            Preferences.Set("PortSettings", port);
            Preferences.Set("ShopSettings", shopSettings);
        }

        private void btnSave_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(IPSetting.Text) && string.IsNullOrWhiteSpace(PortSetting.Text))
            {
                DisplayAlert("الرجاء الانباه", "الرجاء إدخال البيانات", "موافق");
                return;
            }            
            SaveSettings(IPSetting.Text, PortSetting.Text, ShopName.Text);
            DisplayAlert("الرجاء الانباه", "تم حفظ الإعدادات بنجاح", "موافق");
            Navigation.PushModalAsync(new PriceCheckerView());
        }
    }
}