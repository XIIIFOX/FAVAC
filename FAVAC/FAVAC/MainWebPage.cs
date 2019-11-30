//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__       
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FAVAC
{
    public class MainWebPage : ContentPage
    {
        readonly WebView webView = new WebView
        {
            Source = Settings.ChartURL,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };
        readonly ProgressBar progress = new ProgressBar
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Progress = 0.2,
            HeightRequest = 2,
            IsVisible = true
        };
        readonly StackLayout stackLayout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand};
        public MainWebPage()
        {
            webView.Navigating += WebView_Navigating;
            webView.Navigated += WebView_Navigated;
            stackLayout.Children.Add(webView);
            stackLayout.Children.Add(progress);
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            //  MessagingCenter.Unsubscribe<string>(this, "ChangeWebViewKey");
            Content = stackLayout;
            ToolbarItem toolbarItem_settings = new ToolbarItem
            {
                IconImageSource = "ic_tune.png",
                Text = "Settings",
                Priority = 1,
                Order = ToolbarItemOrder.Primary
            };
            ToolbarItem toolbarItem_fullscreen = new ToolbarItem
            {
                IconImageSource = "ic_fullscreen.png",
                Text = "Fullscreen",
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };
            toolbarItem_settings.Clicked += async (s, v) => await Navigation.PushAsync(new ChartSettingsPage());
            toolbarItem_fullscreen.Clicked += async (s, v) => await Navigation.PushAsync(new MainWebPage());
            ToolbarItems.Add(toolbarItem_settings);
            ToolbarItems.Add(toolbarItem_fullscreen);
        }
        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            progress.IsVisible = false;
        }

        private void WebView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            progress.IsVisible = true;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await progress.ProgressTo(0.9, 900, Easing.SpringIn);
            MessagingCenter.Subscribe<object>(this, "ChangeWebViewKey", _ => Device.BeginInvokeOnMainThread(() =>
            {
                webView.Source = Settings.ChartURL;
            }));
        }
    }
}