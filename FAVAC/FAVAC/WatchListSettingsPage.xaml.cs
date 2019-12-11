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
        string[] DataOfItems;
        string[] DataOfLabels;
        int selectedItem = 0;
        public WatchListSettingsPage()
        {
            InitializeComponent();
            WatchListItemsLoad(0);
            MainSettingsLoad(true);
        }

        void MainSettingsLoad(bool _yes)
        {
            if (_yes)
            {
                lang.Text = Settings.Language;
                interval.Text = Settings.Watchlist_Interval;
            }
            else
            {
                Settings.Language = lang.Text;
                Settings.Watchlist_Interval = interval.Text;
            }
        }

        private void _data_Completed(object sender, EventArgs e)
        {
            DataOfItems[selectedItem] = _data.Text;
        }

        void WatchListItemsLoad(int act)
        {
            switch (act)
            {
                case 0:
                    _label.Items.Clear();
                    _data.Text = "";
                    DataOfLabels = Settings.Watchlist_Label.Split('|');
                    foreach (string Name in DataOfLabels)
                    {
                        _label.Items.Add(Name);
                    }
                    DataOfItems = Settings.Watchlist_Data.Split('|');
                    _data.Text = DataOfItems[0];
                    _label.SelectedIndex = 0;
                    break;
                case 1:
                    string readyData = null;
                    foreach (string curent in DataOfItems)
                    {
                        readyData += (readyData != null) ? "|" + curent : curent;
                    }
                    string readyLabel = null;
                    foreach (string label in DataOfLabels)
                    {
                        readyLabel += (readyLabel != null) ? "|" + label : label;
                    }
                    Settings.Watchlist_Label = readyLabel;
                    Settings.Watchlist_Data = readyData;
                    break;
                case 2:
                    CrossSettings.Current.Remove("watchlist_label");
                    CrossSettings.Current.Remove("watchlist_data");
                    WatchListItemsLoad(0);
                    break;
                case 3:
                    Settings.Watchlist_Label = "Info";
                    Settings.Watchlist_Data = "Exchange:Symbol";
                    WatchListItemsLoad(0);
                    break;
            }
        }

        private void _label_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedItem = ((Picker)sender).SelectedIndex;
            try
            {
                _data.Text = DataOfItems[selectedItem];
            }
            catch
            {
                _data.Text = DataOfItems[0];
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            WatchListItemsLoad(1);
            MainSettingsLoad(false);
            MessagingCenter.Send<string>(Settings.Watchlist_Url, "ChangeWatchWebViewKey");
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (await DisplayAlert("Removing...", "Do you want restore settings ?", "Yes", "No"))
            {
                WatchListItemsLoad(2);
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            if (await DisplayAlert("Removing...", "Do you want delete settings ?", "Yes", "No"))
            {
                WatchListItemsLoad(3);
            }
        }

        private void Button_Clicked_2(object sender, EventArgs e)
        {
            CrossSettings.Current.Remove("watchlist_interval");
            CrossSettings.Current.Remove("lang");
            MainSettingsLoad(true);
        }
    }
}