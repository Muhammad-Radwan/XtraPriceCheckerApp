using FakeJSON.Services;
using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XtraPriceCheckerApp.Models;
using XtraPriceCheckerApp.Views;
namespace XtraPriceCheckerApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceCheckerView : ContentPage
    {
        public PriceCheckerView()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            Entry1.Focus();
        }
        private async void Entry1_Completed(object sender, EventArgs e)
        {
            try
            {
                if (Entry1.Text == "69768420184901")
                {
                    await Navigation.PushModalAsync(new SetingsView());
                    Entry1.Text = null;
                    return;
                }
                    

                string _ip = Preferences.Get("IPSettings", null);
                string _port = Preferences.Get("PortSettings", null);
                List<TBL007> PricesList = await new JsonService().GetPrice(_ip, _port, Entry1.Text);
                if (PricesList.Count > 0)
                {
                    LBLPrice.Text = PricesList[0].EndUserPrice.ToString() + " د.ل";
                    LBLProductName.Text = PricesList[0].ProductName;
                    //await TextToSpeech.SpeakAsync(Entry1.Text, );
                    //TextToSpeech.
                }
                else
                {
                    LBLProductName.Text = "الصنف غير موجود";
                    LBLPrice.Text = "0.00";
                    Entry1.Text = null;
                    Entry1.Focus();
                }
                Entry1.Text = null;
                Entry1.Focus();
                
            }
            catch (Exception ex)
            {
                await DisplayAlert("الرجاء الانتباه", "حدث خطأ أثناء محاولة جلب البيانات" + Environment.NewLine + ex.Message, "موافق");
            }

        }

        private void Settings_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SetingsView());
        }

        private void Entry1_Unfocused(object sender, FocusEventArgs e)
        {
            Entry1.Focus();
        }
    }
}