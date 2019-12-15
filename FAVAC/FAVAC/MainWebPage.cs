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
using Xamarin.Forms;
using Xamarin.Forms.Internals;
using ZXing.Net.Mobile.Forms;

namespace FAVAC
{
    public class MainWebPage : ContentPage
    {
        readonly WebView webView = new WebView
        {
            Source = Settings.ChartURL,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            BackgroundColor = Color.FromHex("#212121")
        };
        readonly ProgressBar progress = new ProgressBar
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            Progress = 0.2,
            BackgroundColor = Color.Transparent,
            HeightRequest = 2,
            IsVisible = true
        };
        readonly StackLayout stackLayout = new StackLayout { VerticalOptions = LayoutOptions.FillAndExpand, HorizontalOptions = LayoutOptions.FillAndExpand, BackgroundColor= Color.FromHex("#212121")};
        public MainWebPage()
        {
            stackLayout.Children.Add(webView);
            stackLayout.Children.Add(progress);
            webView.Navigating += WebView_Navigating;
            webView.Navigated += WebView_Navigated;
            SetValue(NavigationPage.HasNavigationBarProperty, false);
            //  MessagingCenter.Unsubscribe<string>(this, "ChangeWebViewKey");
            Content = stackLayout;
            ToolbarItem toolbarItem_settings = new ToolbarItem
            {
                IconImageSource = "ic_tune.png",
                Text = "Settings",
                Priority = 3,
                Order = ToolbarItemOrder.Primary
            };
            ToolbarItem toolbarItem_scan = new ToolbarItem
            {
                IconImageSource = "ic_qrcode_scan.png",
                Text = "Scan",
                Priority = 2,
                Order = ToolbarItemOrder.Primary
            };
            ToolbarItem toolbarItem_reload = new ToolbarItem
            {
                IconImageSource = "ic_reload.png",
                Text = "Reload",
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
            toolbarItem_scan.Clicked += ToolbarItem_scan_Clicked;
            toolbarItem_reload.Clicked += (s, v) => webView.Source = Settings.ChartURL;
            toolbarItem_fullscreen.Clicked += async (s, v) => await Navigation.PushAsync(new MainWebPage());
            ToolbarItems.Add(toolbarItem_settings);
            ToolbarItems.Add(toolbarItem_fullscreen);
            ToolbarItems.Add(toolbarItem_reload);
            ToolbarItems.Add(toolbarItem_scan);
        }

        private async void ToolbarItem_scan_Clicked(object sender, EventArgs e)
        {
            try
            {
                var scannerPage = new ZXingScannerPage
                {
                    Title = "Scan QR"
                };
                scannerPage.OnScanResult += (result) =>
                {
                    scannerPage.IsScanning = false;

                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Navigation.PopAsync();
                        ResultOfQRScanning(result.Text);
                    });
                };

                await Navigation.PushAsync(scannerPage);
            }
            catch (Exception ex)
            {
                Log.Warning("Middle", ex.Message);
            }
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
            MessagingCenter.Subscribe<string>(this, "ChangeWebViewKey", webUrl => Device.BeginInvokeOnMainThread(() =>
            {
                webView.Source = webUrl;
            }));
            try
            {
                await progress.ProgressTo(0.9, 900, Easing.SpringIn);
            }
            catch (Exception e)
            {
                Log.Warning("low", e.ToString());
            }
        }
        async void ResultOfQRScanning(string result)
        {
            var option = await DisplayAlert("Succes!", "Do you want try this chart or set settings?" + result, "Set settings", "Try");
            if (option)
            {
                Settings.ChartDATA = result;
                webView.Source = Settings.ChartURL;
            }
            else
            {
                MessagingCenter.Send<string>(result.Split('*')[1], "ChangeWebViewKey");
            }
        }
    }
}