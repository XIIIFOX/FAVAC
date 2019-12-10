//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__
using Plugin.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WatchListSettingsPage : ContentPage
    {
        string[] DataOfItems = Settings.Watchlist_Data.Split('|');
        int selectedItem = 0;
        public WatchListSettingsPage()
        {
            InitializeComponent();
            WatchListItemsLoad(true);
        }

        private void _data_Completed(object sender, EventArgs e)
        {
            DataOfItems[selectedItem] = _data.Text;
         //   Settings.Watchlist_Url = $"https://s.tradingview.com/embed-widget/market-overview/?locale=uk#%7B%22colorTheme%22%3A%22dark%22%2C%22dateRange%22%3A%2212m%22%2C%22showChart%22%3Atrue%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22largeChartUrl%22%3A%22%22%2C%22isTransparent%22%3Afalse%2C%22plotLineColorGrowing%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22plotLineColorFalling%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22gridLineColor%22%3A%22rgba(42%2C%2046%2C%2057%2C%201)%22%2C%22scaleFontColor%22%3A%22rgba(120%2C%20123%2C%20134%2C%201)%22%2C%22belowLineFillColorGrowing%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22belowLineFillColorFalling%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22symbolActiveColor%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22tabs%22%3A%5B%7B%22title%22%3A%22Forex%22%2C%22symbols%22%3A%5B%7B%22s%22%3A%22FX%3AEURUSD%22%7D%2C%7B%22s%22%3A%22FX%3AGBPUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDJPY%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCHF%22%7D%2C%7B%22s%22%3A%22FX%3AAUDUSD%22%7D%2C%7B%22s%22%3A%22FX%3AUSDCAD%22%7D%2C%7B%22s%22%3A%22FX%3AEURUSD%22%7D%5D%2C%22originalTitle%22%3A%22Forex%22%7D%5D%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22market-overview%22%7D";
        }

        void WatchListItemsLoad(bool _yes)
        {
            if (_yes)
            {
                foreach (string Name in Settings.Watchlist_Label.Split('|'))
                {
                    _label.Items.Add(Name);
                }
                _data.Text = DataOfItems[selectedItem];
                _label.SelectedIndex = selectedItem;
            }
            else
            {
                string readyData = null;
                foreach (string curent in DataOfItems)
                {
                    readyData += (readyData != null) ? "|" + curent : curent;
                }
                Settings.Watchlist_Data = readyData;
            }
        }

        private void _label_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = ((Picker)sender).SelectedIndex;
            _data.Text = DataOfItems[selectedItem];
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            WatchListItemsLoad(false);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            var option = await DisplayAlert("Removing...", "Do you want restore settings ?", "Yes", "No");
            if (option)
            {
                CrossSettings.Current.Remove("watchlist_label");
                CrossSettings.Current.Remove("watchlist_data");
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            var option = await DisplayAlert("Removing...", "Do you want delete settings ?", "Yes", "No");
            if (option)
            {
                Settings.Watchlist_Label = "Info";
                Settings.Watchlist_Data = "";
            }
        }
    }
}