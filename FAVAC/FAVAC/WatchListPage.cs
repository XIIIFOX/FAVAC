//______/\\\_____/\\\\\\\\\\___/\\\\\\\\\\\\\\\_______/\\\\\_______/\\\_______/\\\_
// __/\\\\\\\___/\\\///////\\\_\/\\\///////////______/\\\///\\\____\///\\\___/\\\/__                                                                                                                                                                                  
//  _\/////\\\__\///______/\\\__\/\\\_______________/\\\/__\///\\\____\///\\\\\\/____                                                                                                                                                                                 
//   _____\/\\\_________/\\\//___\/\\\\\\\\\\\______/\\\______\//\\\_____\//\\\\______                                                                                                                                                                                
//    _____\/\\\________\////\\\__\/\\\///////______\/\\\_______\/\\\______\/\\\\______                                                                                                                                                                               
//     _____\/\\\___________\//\\\_\/\\\_____________\//\\\______/\\\_______/\\\\\\_____                                                                                                                                                                              
//      _____\/\\\__/\\\______/\\\__\/\\\______________\///\\\__/\\\_______/\\\////\\\___                                                                                                                                                                             
//       _____\/\\\_\///\\\\\\\\\/___\/\\\________________\///\\\\\/______/\\\/___\///\\\_                                                                                                                                                                            
//        _____\///____\/////////_____\///___________________\/////_______\///_______\///__
using Xamarin.Forms;

namespace FAVAC
{
    public class WatchListPage : ContentPage
    {
        readonly WebView webView = new WebView();
        bool ready = false;
        public WatchListPage()
        {
            webView.Margin = new Thickness(-2);
            webView.BackgroundColor = Color.FromHex("#212121");
            webView.Source = Settings.Watchlist_Url;
            webView.Navigating += (s, e) => { e.Cancel = (ready) ? true : false; if (!ready) ready = true; };
            Content = webView;

            ToolbarItem toolbarItem_settings = new ToolbarItem
            {
                IconImageSource = "ic_tune.png",
                Text = "Settings",
                Priority = 0,
                Order = ToolbarItemOrder.Primary
            };
            toolbarItem_settings.Clicked += async (s, v) => await Navigation.PushAsync(new WatchListSettingsPage());
            ToolbarItems.Add(toolbarItem_settings);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<string>(this, "ChangeWatchWebViewKey", webUrl => Device.BeginInvokeOnMainThread(() =>
            {
                ready = false;
                webView.Source = webUrl;
            }));
        }
    }
}