using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using Xamarin.Forms;

namespace FAVAC
{
    public class WatchListPage : ContentPage
    {
        readonly WebView webView = new WebView();
        public WatchListPage()
        {
            switch (Device.RuntimePlatform)
            {
                case Device.Android:
                    webView.Source = "file:///android_asset/watchlist.htm";
                    break;
                case Device.iOS:
                    webView.Source = "";
                    break;
            }
            webView.Navigated += WebView_Navigated;
            Content = webView;

            ToolbarItem toolbarItem_settings = new ToolbarItem
            {
                IconImageSource = "ic_tune.png",
                Text = "Settings",
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };
            toolbarItem_settings.Clicked += async (s, v) => await Navigation.PushAsync(new ChartSettingsPage());
            ToolbarItems.Add(toolbarItem_settings);
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            
        }
    }
}