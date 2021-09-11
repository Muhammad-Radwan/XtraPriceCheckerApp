using FakeJSON.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using XtraPriceCheckerApp.Models;

namespace XtraPriceCheckerClient
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ZXingScannerView_OnScanResult(ZXing.Result result)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                GetPrice(result.Text);
            });
        }

        private async void GetPrice(string Rslt)
        {
            try
            {
                string _ip = Preferences.Get("IPSettings", null);
                string _port = Preferences.Get("PortSettings", null);
                List<TBL007> PricesList = await new JsonService().GetPrice("192.168.43.166", "8081", Rslt);
                if (PricesList.Count > 0)
                {
                    lblPrice.Text = PricesList[0].EndUserPrice.ToString() + " د.ل";
                    lblProductName.Text = PricesList[0].ProductName;
                }
                else
                {
                    lblProductName.Text = "الصنف غير موجود";
                    lblPrice.Text = "0.00";
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("الرجاء الانباه", "حدث خطأ أثناء محاولة جلب البيانات" + Environment.NewLine + ex.Message, "موافق");
            }
        }
    }
}
