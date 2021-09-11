using FakeJSON.Services;
using FakeJSON.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XtraPriceCheckerApp.Models;

namespace XtraPriceCheckerApp.ViewModels
{
    public class PriceCheckerViewModel : BaseViewModel
    {

        private List<TBL007> _tbl007;
        public List<TBL007> Tbl007
        {
            get => _tbl007;
            set
            {
                SetValue(ref _tbl007, value);
            }
        }

        public ICommand GetPrices
        {
            get
            {
                return new Command(() =>
                {
                    //await GetPrices()
                });
            }
        }

        private async void GetPrice(string IP, string Port, string BarCode)
        {
            _tbl007 = await new JsonService().GetPrice(IP, Port, BarCode);
        }
    }
}
