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
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FAVAC
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MorePage : ContentPage
    {
        public List<CommonMenuItem> ElementsOthers { get; set; }
        public List<CommonMenuItem> Elements { get; set; }

        public MorePage()
        {
            InitializeComponent();

            ToolbarItem toolbarItemSettings = new ToolbarItem
            {
                Text = "Settings",
                Priority = 1,
                Order = ToolbarItemOrder.Primary,
                IconImageSource = "ic_settings.png"
            };
            ToolbarItem toolbarItemShare = new ToolbarItem
            {
                Text = "Share",
                Priority = 0,
                Order = ToolbarItemOrder.Primary,
                IconImageSource = "ic_share.png"
            };

            toolbarItemShare.Clicked += (s, e) =>
            {
                Share.RequestAsync(new ShareTextRequest
                {
                    Uri = "https://play.google.com/store/apps/dev?id=8434535627357546284",
                    Title = "Share This App"
                });
            };
            ToolbarItems.Add(toolbarItemSettings);
            ToolbarItems.Add(toolbarItemShare);

            Elements = new List<CommonMenuItem> {
            new CommonMenuItem {Title="Stock Market", ImagePath="ic_chart_gantt.png" },
            new CommonMenuItem {Title="Forex Cross Rates", ImagePath="ic_checkerboard.png" },
            new CommonMenuItem {Title="Forex Heat Map", ImagePath="ic_chart_scatter_plot.png" },
            new CommonMenuItem {Title="Screener", ImagePath="ic_chevron_double_up.pngg" },
            new CommonMenuItem {Title="Cryptocurrency Market", ImagePath="ic_bitcoin.png" }
            };

            ElementsOthers = new List<CommonMenuItem>
            {
                  new CommonMenuItem {Title="Site", ImagePath="ic_select.png" },
            new CommonMenuItem {Title="About", ImagePath="ic_information.png" }
            };
            this.BindingContext = this;
        }

        public class CommonMenuItem
        {
            public string Title { get; set; }
            public string ImagePath { get; set; }
        }

        private async void itemsList_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
                await Navigation.PushAsync(new WebViewHand());
                switch (e.ItemIndex)
                {
                    case 0:
                        MessagingCenter.Send((e.Item as CommonMenuItem).Title + "|https://s.tradingview.com/embed-widget/hotlists/?locale=en#%7B%22colorTheme%22%3A%22dark%22%2C%22dateRange%22%3A%2212m%22%2C%22exchange%22%3A%22US%22%2C%22showChart%22%3Atrue%2C%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22largeChartUrl%22%3A%22%22%2C%22isTransparent%22%3Afalse%2C%22plotLineColorGrowing%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22plotLineColorFalling%22%3A%22rgba(25%2C%20118%2C%20210%2C%201)%22%2C%22gridLineColor%22%3A%22rgba(42%2C%2046%2C%2057%2C%201)%22%2C%22scaleFontColor%22%3A%22rgba(120%2C%20123%2C%20134%2C%201)%22%2C%22belowLineFillColorGrowing%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22belowLineFillColorFalling%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22symbolActiveColor%22%3A%22rgba(33%2C%20150%2C%20243%2C%200.12)%22%2C%22utm_source%22%3A%22www.tradingview.com%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22hotlists%22%7D", "SetWebViewKey");
                        break;
                    case 1:
                        MessagingCenter.Send((e.Item as CommonMenuItem).Title + "|https://s.tradingview.com/embed-widget/forex-cross-rates/?locale=en#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22currencies%22%3A%5B%22EUR%22%2C%22USD%22%2C%22JPY%22%2C%22GBP%22%2C%22CHF%22%2C%22AUD%22%2C%22CAD%22%2C%22NZD%22%2C%22CNY%22%5D%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22forex-cross-rates%22%7D", "SetWebViewKey");
                        break;
                    case 2:
                        MessagingCenter.Send((e.Item as CommonMenuItem).Title + "|https://s.tradingview.com/embed-widget/forex-heat-map/?locale=en#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22currencies%22%3A%5B%22EUR%22%2C%22USD%22%2C%22JPY%22%2C%22GBP%22%2C%22CHF%22%2C%22AUD%22%2C%22CAD%22%2C%22NZD%22%2C%22CNY%22%5D%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22forex-heat-map%22%7D", "SetWebViewKey");
                        break;
                    case 3:
                        MessagingCenter.Send((e.Item as CommonMenuItem).Title + "|https://s.tradingview.com/embed-widget/screener/?locale=en#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22defaultColumn%22%3A%22overview%22%2C%22defaultScreen%22%3A%22general%22%2C%22market%22%3A%22forex%22%2C%22showToolbar%22%3Atrue%2C%22colorTheme%22%3A%22dark%22%2C%22enableScrolling%22%3Atrue%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22forexscreener%22%7D", "SetWebViewKey");
                        break;
                    case 4:
                        MessagingCenter.Send((e.Item as CommonMenuItem).Title + "|https://s.tradingview.com/embed-widget/crypto-mkt-screener/?locale=en#%7B%22width%22%3A%22100%25%22%2C%22height%22%3A%22100%25%22%2C%22defaultColumn%22%3A%22overview%22%2C%22screener_type%22%3A%22crypto_mkt%22%2C%22displayCurrency%22%3A%22USD%22%2C%22colorTheme%22%3A%22dark%22%2C%22market%22%3A%22crypto%22%2C%22enableScrolling%22%3Atrue%2C%22utm_source%22%3A%22%22%2C%22utm_medium%22%3A%22widget_new%22%2C%22utm_campaign%22%3A%22cryptomktscreener%22%7D", "SetWebViewKey");
                        break;
                }
            }
        }

        private async void itemsListOther_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            if (e.Item != null)
            {
                ((ListView)sender).SelectedItem = null;
                switch (e.ItemIndex)
                {
                    case 0:
                        await Browser.OpenAsync(new Uri("https://vk.com"), new BrowserLaunchOptions
                        {
                            LaunchMode = BrowserLaunchMode.SystemPreferred,
                            TitleMode = BrowserTitleMode.Show,
                            PreferredToolbarColor = Color.AliceBlue,
                            PreferredControlColor = Color.Violet
                        });
                        break;
                    case 1:
                        await Navigation.PushAsync(new AboutPage());
                        break;
                }
            }
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new DataPage());
        }
    }
}