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
    public class NewsIdeasPage : ContentPage
    {
        WebView webView = new WebView
        {
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand
        };
        public NewsIdeasPage()
        {

            ToolbarItem toolbarItem = new ToolbarItem
            {
                Priority = 0,
                Order = ToolbarItemOrder.Primary,
                Text = "Ideas"
            };
            toolbarItem.Clicked += (s, e) =>
            {
                if ((s as ToolbarItem).Text == "News")
                {
                    (s as ToolbarItem).Text = "Ideas";
                    OnSelect(true);
                }
                else
                {
                    (s as ToolbarItem).Text = "News";
                    OnSelect(false);
                }
            };
            OnSelect(true);
                ToolbarItems.Add(toolbarItem);
            Content = webView;
        }

        void OnSelect(bool news)
        {
           if (news) { 
                webView.Source = $"https://s.tradingview.com/embed-widget/events/?locale={Settings.Language}#%7B%22colorTheme%22%3A%22dark%22%2C%22isTransparent%22%3Afalse%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22importanceFilter%22%3A%22-1%2C0%2C1%22%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22events%22%7D";
                webView.Margin = new Thickness(-2);
            } else {
                webView.Source = "https://tradingview.com/ideas/";
                webView.Margin = new Thickness(-2, -123, -2, -2);
            }
        }
    }
}